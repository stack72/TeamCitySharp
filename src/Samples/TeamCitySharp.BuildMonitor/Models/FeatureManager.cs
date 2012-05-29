using System;
using System.ComponentModel;
using System.Configuration;

namespace BuildMonitor.Models
{
    public interface IFeatureManager
    {
        string GetSwitchSetting(string propertyName);
        T GetSwitchSetting<T>(string propertyName) where T : struct;
    }

    public class FeatureManager : IFeatureManager
    {
        public string GetSwitchSetting(string propertyName)
        {
            return ConfigurationManager.AppSettings.Get(propertyName);
        }

        public T GetSwitchSetting<T>(string propertyName) where T : struct
        {
            if (propertyName == null)
                throw new ArgumentNullException("propertyName");

            var value = GetSwitchSetting(propertyName);

            T returnVal = default(T);
            if (String.IsNullOrEmpty(value))
                return returnVal;

            TryParse(value, out returnVal);
            return returnVal;
        }

        private static bool TryParse<T>(string s, out T value)
        {
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));
            try
            {
                value = (T)converter.ConvertFromString(s);
                return true;
            }
            catch
            {
                value = default(T);
                return false;
            }
        }
    }
}