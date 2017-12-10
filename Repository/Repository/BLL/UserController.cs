using Repository.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.BLL
{
   public class UserController
    {
        public static async Task<SignInStatus> Login(string userName, string password)
        {
            var user = await UserDataAccessor.GetUser(userName);

            if(user.LoginName == userName && user.PasswordHash == password)
                return SignInStatus.Success;
            else
                return SignInStatus.Failure;
        }

        public static async Task<SMA_Lookup_User> GetUser(string userName)
        {
            var user = await UserDataAccessor.GetUser(userName);

            return user;
        }
    }
}
