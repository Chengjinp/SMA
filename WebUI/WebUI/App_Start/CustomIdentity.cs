using System;
using System.Security.Principal;
using System.Runtime.Serialization;

namespace WebUI
{
    [Serializable]
    [KnownType(typeof(CustomIdentity))]
    public class CustomUser : IPrincipal
    {
        public CustomUser()
        {

        }

        public CustomUser(string name, int userId, string additionalInfo)
        {
            Identity = new CustomIdentity(name, userId, additionalInfo);
        }

        public IIdentity Identity { get; private set; }

        public bool IsInRole(string role)
        {
            return true;
        }
    }

    [Serializable]
    public class CustomIdentity : IIdentity
    {
        public CustomIdentity()
        {

        }
        public CustomIdentity(string name, int userId, string additionalInfo)
        {
            Name = name;
            UserId = userId;
            AdditionalInfo = additionalInfo;
        }

        public string Name { get; private set; }

        public string AuthenticationType
        {
            get { return "CustomAuth"; }
        }

        public bool IsAuthenticated
        {
            get { return !String.IsNullOrEmpty(Name); }
        }

        public int UserId { get; private set; }
        public string AdditionalInfo { get; private set; }
    }

}
