using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AppTests.Facades
{
    public static class ConfigurationFacade
    {

        public static IConfiguration BuildConfiguraion()
        {
           return new ConfigurationBuilder()
          .SetBasePath($@"{Directory.GetCurrentDirectory()}\..\..\..\..\..\Web" )
          .AddJsonFile("appsettings.json")
          .Build();
        }

    }
}
