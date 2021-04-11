using System;
using System.IO;
using System.Globalization;
using Microsoft.Extensions.Configuration;

namespace Parser2Gis
{
    public class AuthConfig
    {
        public string Url { get; set; }
        public string UserAgent { get; set; }
        public string Referer { get; set; }
        public string Accept { get; set; }        
   
        public static AuthConfig ReadFromJsonFile(string path)
        {
            IConfiguration Configuration;
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(path);

            Configuration = builder.Build();

            return Configuration.Get<AuthConfig>();
        }
    }
}
