using System;
using System.Configuration;

namespace SonosApi.Helpers
{
    public class ConfigurationHelper
    {
        internal static string GetSonosIp()
        {
            return GetStringFromConfiguration("SonosIp", false);
        }

        private static string GetStringFromConfiguration(string key, bool optional)
        {
            var value = ConfigurationManager.AppSettings[key];
            if (!string.IsNullOrWhiteSpace(value))
            {
                return value;
            }
            if (optional)
            {
                return "";
            }
            else
            {
                throw new ArgumentNullException("key");
            }
        }

        void dd()
        {

        }
    }
}
