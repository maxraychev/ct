using System.Configuration;

namespace CoolToolSite.Tests.Entities
{
    public class User
    {
        private static string _login;
        
        private static string _password;
        private static string _name;

        public static string Login
        {
            get { return _login ?? (_login = ConfigurationManager.AppSettings["Login"]); }
            set { _login = value; }
        }

        public static string Password
        {
            get { return _password ?? (_password = ConfigurationManager.AppSettings["Password"]); }
            set { _password = value; }
        }

        public static string Name
        {
            get { return _name ?? (_name = ConfigurationManager.AppSettings["Login"].Substring(0, 12)); }
            set { _name = value; }
        }



    }
}
