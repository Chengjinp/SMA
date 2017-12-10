using Repository.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Repository.DAL.Data
{
   public class UserDataAccessor
    {
        public static async Task<SMA_Lookup_User> GetUser(string userName)
        {
            using (var context = new AppDb_SMAEntities())
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
