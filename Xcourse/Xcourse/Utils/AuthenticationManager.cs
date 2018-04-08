using System;
using System.Collections.Generic;
using System.Text;

namespace Xcourse.Utils
{
    public static class AuthenticationManager
    {
        public static bool Login(string username, string password)
        {
            if (username == "user")
            {
                PersistanceUtil.SetValueByKey(PersistanceUtil.Keys.Username.ToString(), username);
                return true;
            }
            return false;
        }

        public static bool Logout()
        {
            PersistanceUtil.RemoveKey(PersistanceUtil.Keys.Username.ToString());
            return true;
        }

        public static bool IsLoggedIn() => PersistanceUtil.HasKey(PersistanceUtil.Keys.Username.ToString());
    }
}
