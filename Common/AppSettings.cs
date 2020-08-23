using Common.Extensions;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;

namespace Common
{
    public static class AppSettings
    {
        private static Dictionary<string, object> _Settings = new Dictionary<string, object>();

        public static string LocalPath { get; private set; }
        public static string JwtKey => Get<string>(nameof(JwtKey));
        public static int TokenExpirationMinutes => Get<int>(nameof(TokenExpirationMinutes));
        public static string AllowedOrigins => Get<string>(nameof(AllowedOrigins));
        public static string WebsiteUrl => Get<string>(nameof(WebsiteUrl));
        public static string EmailTemplatePath => Get<string>(nameof(EmailTemplatePath)).GetWithLocalPath();
        public static string EmailSettingsFrom => Get<string>(nameof(EmailSettingsFrom));
        public static string EmailSettingsFromName => Get<string>(nameof(EmailSettingsFromName));
        public static string EmailSettingsHost => Get<string>(nameof(EmailSettingsHost));
        public static string EmailSettingsUsername => Get<string>(nameof(EmailSettingsUsername));
        public static string EmailSettingsPassword => Get<string>(nameof(EmailSettingsPassword));
        public static int EmailSettingsPort => Get<int>(nameof(EmailSettingsPort));
        public static bool EmailSettingsEnableSsl => Get<bool>(nameof(EmailSettingsEnableSsl));
        public static int ResetKeyDurationInMinutes => Get<int>(nameof(ResetKeyDurationInMinutes));

        public static void SetLocalPath(string localPath)
        {
            LocalPath = localPath;
        }

        private static T Get<T>(string key)
        {
            if (_Settings.ContainsKey(key))
            {
                return (T)_Settings[key];
            }
            try
            {
                string setting = ConfigurationManager.AppSettings[key];
                if (setting == null)
                {
                    T defaultValue = default;
                    lock (_Settings)
                    {
                        if (!_Settings.ContainsKey(key))
                        {
                            _Settings.Add(key, defaultValue);
                        }
                    }
                    return defaultValue;
                }
                TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));
                object value = converter.ConvertFromInvariantString(setting);
                T convertedValue = (T)value;
                lock (_Settings)
                {
                    if (_Settings.ContainsKey(key))
                    {
                        _Settings[key] = convertedValue;
                    }
                    else
                    {
                        _Settings.Add(key, convertedValue);
                    }
                }
                return convertedValue;
            }
            catch (System.Exception)
            {
                return default;
            }
        }
    }
}
