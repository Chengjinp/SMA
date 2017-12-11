using Repository.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                //Extract the forms authentication cookie
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                // Create an Identity object
                //CustomIdentity implements System.Web.Security.IIdentity

                //userData = Json(user).Data.ToString();

                //JsonController.Deserialize<IPrincipal>(authTicket.UserData);

                //string[] userData = authTicket.UserData.Split(new char[] { '=' });

                //userData = userData + "UserName=" + model.UserName;
                //FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, model.UserName, DateTime.Now, DateTime.Now.AddMinutes(30), true, userData);
                

                //var dbUser = UserController.GetUser(authTicket.Name).Result;
                //CustomPrincipal implements System.Web.Security.IPrincipal
                //CustomUser newUser = new CustomUser(userData[1], 0, "");
                Context.User = (IPrincipal)JsonController.Deserialize<CustomUser>(authTicket.UserData);
            }
        }
    }
}
