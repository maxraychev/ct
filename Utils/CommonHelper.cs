using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;

namespace CoolToolSite.Tests.Utils
{
    public static class CommonHelper
    {
        private static readonly string RemoveUrl = ConfigurationManager.AppSettings["BaseUrl"] +
                                           ConfigurationManager.AppSettings["RemoveUserPath"];

        private static WebResponse _objResponse;
        public static string Driver;

        public static void RemoveTestUser()
        {
            try
            {
                var request = WebRequest.Create(RemoveUrl);
                _objResponse = request.GetResponse();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static void SetDriver(string driver)
        {
            Driver = driver;
        }

        public static string GetDriver()
        {
            return Driver;
        }
    }
}
