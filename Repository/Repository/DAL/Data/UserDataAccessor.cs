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




        public static async Task<SMA_Lookup_User> GetUserByUsername(string userName)
        {
            using (var context = GetDBContext())
            {
                var users = await (from u in context.SMA_Lookup_User
                                   where u.LoginName == userName
                                   select u
                                   ).ToListAsync();

                if (users == null || users.Count != 1)
                    throw new Exception("user not existing or find multiple user with same email address");
                else
                    return users.First();
            }
        }

    }
}
