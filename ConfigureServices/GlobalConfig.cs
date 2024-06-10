using Microsoft.Extensions.Hosting;
using System.Globalization;

namespace WEB_API_2024.ConfigureServices
{
    public static class GlobalConfig
    {
        public static string LiveURL = "webapi.jaipurrugs.com";      
        public static string LocalHost = "localhost";

        private static IHttpContextAccessor HttpContextAccessor;
        private static IWebHostEnvironment _env;

        private static CultureInfo hindi = new CultureInfo("hi-IN");
        public static void Configure(IHttpContextAccessor httpContextAccessor, IWebHostEnvironment env)
        {
            HttpContextAccessor = httpContextAccessor;
            _env = env;

        }

        public static string GetHostURL()
        {
            string host = "";
            //if (host != "")
            //{
            //    return host;
            //}
            //else
            //{

            //    //string Host = HttpContextAccessor.HttpContext.Request.Host.ToString().ToLower();

            //    if (Host.ToLower().Contains(LiveURL.ToLower()))
            //    {
            //        host = "https://" + LiveURL + "/";
            //    }               
            //    else if (Host.ToLower().Contains(LocalHost.ToLower()))
            //    {
            //        host = "https://" + LocalHost + ":53149/";
            //    }
            //    else
            //    {
            //        host = "";
            //    }

            //    return host;

            //}

           host = "https://" + LiveURL + "/";
            //host = "https://" + LocalHost + ":53149/";
            return host;
        }
    }
}
