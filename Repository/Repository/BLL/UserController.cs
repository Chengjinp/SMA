using System.Threading.Tasks;
using Repository.DAL.Data;

namespace Repository.BLL
{
    public class UserController
    {
        public static async Task<SignInStatus> Login(string userName, string password)
        {
            var user = await UserDataAccessor.GetUserByUsername(userName);

            if(user.LoginName.ToLower() == userName.ToLower() && user.PasswordHash == password)
                return SignInStatus.Success;
            else
                return SignInStatus.Failure;
        }

        public static async Task<SMA_Lookup_User> GetUserByUsername(string userName)
        {
            var user = await UserDataAccessor.GetUserByUsername(userName);

            return user;
        }
    }
}
