using System;

namespace Repository.BLL
{
    public class SettingController
    {
        public static T Get<T>(string key)
        {
            var value = System.Configuration.ConfigurationManager.AppSettings.Get(key);

            return (T)Convert.ChangeType(value, typeof(T));

        }
    }
}
