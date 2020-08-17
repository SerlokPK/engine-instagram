using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;

namespace Common
{
    public static class AppSettings
    {
        private static Dictionary<string, object> _Settings = new Dictionary<string, object>();

        public static string JwtKey => Get<string>(nameof(JwtKey));
        public static int TokenExpirationMinutes => Get<int>(nameof(TokenExpirationMinutes));

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
