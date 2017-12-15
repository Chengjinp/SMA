using System.Threading.Tasks;
using Repository.DAL.Data;

namespace Repository.BLL
{
    public class UserController
    {
        public static async Task<SignInStatus> Login(string userName, string password)
        {
            var user = await UserDataAccessor.GetUserByUsername(userName);

            if (user == null)
                return SignInStatus.Failure;

            var inputPasswordHash = CryptoController.GenerateSaltedHash(password, user.Sel);


            if(user.PasswordHash == inputPasswordHash)
                return SignInStatus.Success;
            else
                return SignInStatus.Failure;
        }

        public static async Task<SignUpStatus> Register(string userName, string password)
        {
            var user = await UserDataAccessor.GetUserByUsername(userName);

            if (user != null)
                return SignUpStatus.UserExist;




            return SignUpStatus.Success;
        }

        public static async Task<SMA_Lookup_User> GetUserByUsername(string userName)
        {
            var user = await UserDataAccessor.GetUserByUsername(userName);

            return user;
        }
    }
}
