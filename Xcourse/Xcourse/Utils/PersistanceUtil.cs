using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Xcourse.Utils
{
    public static class PersistanceUtil
    {
        public static bool HasKey(string key) => Application.Current.Properties.ContainsKey(key);
        public static object GetValueByKey(string key) => Application.Current.Properties[key];
        public static void SetValueByKey(string key, string value) => Application.Current.Properties[key] = value;
        public static bool RemoveKey(string key) => Application.Current.Properties.Remove(key);

        public enum Keys
        {
            Username,
            Jwt
        }
    }
}
