using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace core_utilities
{
    public class ConfigFunction
    {
        public static IConfiguration Configuration { get; set; }
        public static string GetConfig(string configName)
        {
            var builder = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json");
            Configuration = builder.Build();
            return Configuration[configName];
        }
    }
}
