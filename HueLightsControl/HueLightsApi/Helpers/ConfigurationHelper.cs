using System;
using System.Configuration;

namespace HueLightsApi.Helpers
{
    public class ConfigurationHelper
    {
        internal static string GetHueBridgeApiUri()
        {
            return GetStringFromConfiguration("HueBridgeApiUri", false);
        }
        internal static string GetHueAuthenticatedUser()
        {
            return GetStringFromConfiguration("HueAuthenticatedUser", false);
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

        void dd () {
            
        }
    }
}
