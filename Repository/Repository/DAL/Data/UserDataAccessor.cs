using System;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Repository.BLL;

namespace Repository.DAL.Data
{
    public class UserDataAccessor
    {
        public static AppDb_SMAEntities GetDBContext()
        {
            var dbContext = new AppDb_SMAEntities();

            if(SettingController.Get<int>("IsLive") == 1)
            {
                SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder();
                // Set the properties for the data source.
                sqlBuilder.DataSource = "APL-MZHANG-W8\\SQLEX2017";
                sqlBuilder.InitialCatalog = "AppDb_SMA";
                sqlBuilder.IntegratedSecurity = false;
                sqlBuilder.UserID = "sma";
                sqlBuilder.Password = "gtyh68@#";

                dbContext.Database.Connection.ConnectionString = sqlBuilder.ConnectionString;
            }

            return dbContext;
        }


        /// <summary>
        /// Get User By username
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static async Task<SMA_Lookup_User> GetUserByUsername(string userName)
        {
            using (var context = GetDBContext())
            {
                var users = await (from u in context.SMA_Lookup_User
                                   where u.LoginName.ToLower() == userName.ToLower()
                                   select u
                                   ).ToListAsync();

                if (users == null || users.Count != 1)
                    throw new Exception("user not existing or find multiple user with same email address");
                else
                    return users.First();
            }
        }

        /// <summary>
        /// add a new user to DB
        /// </summary>
        /// <param name="enterUserId"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="roleId"></param>
        /// <param name="contactId"></param>
        /// <returns></returns>
        public static async Task<SignUpStatus> AddUser(int? enterUserId, string userName, string password, string firstName, string lastName, int? roleId, int? contactId)
        {
            using (var context = GetDBContext())
            {
                var user = GetUserByUsername(userName);

                if (user != null)
                    return SignUpStatus.UserExist;

                SMA_Lookup_User entityUser = new SMA_Lookup_User();
                entityUser.LoginName = userName;
                entityUser.Sel = CryptoController.CreateSalt(12);
                entityUser.PasswordHash = CryptoController.GenerateSaltedHash(password, entityUser.Sel);
                entityUser.FirstName = firstName;
                entityUser.LastName = lastName;
                entityUser.EnterDate = DateTime.Now;
                entityUser.IsActive = true;
                entityUser.EnterUserId = enterUserId;
                entityUser.RoleId = roleId;
                entityUser.ContactId = contactId;

                context.SMA_Lookup_User.Add(entityUser);
                var result = await context.SaveChangesAsync();


                if (result > 0)
                {
                    return SignUpStatus.Success;
                }

                return SignUpStatus.Failure;
            }
        }

    }
}
