using System.Configuration;

namespace NWC.Helper.Layer
{
    public static class ConfigurationHelper
    {
        /// <summary>
        /// Helper function to obtain settings from AppSettings
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetConfigurations(string name)
        {
            string setting = ConfigurationManager.AppSettings[name];
            return (!string.IsNullOrEmpty(setting)) ? setting : string.Empty;
        }
    }
}