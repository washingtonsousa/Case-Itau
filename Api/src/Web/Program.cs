using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Itau.Case.Brasileirao.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
             .UseDefaultServiceProvider(options =>
                    options.ValidateScopes = false)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                }).ConfigureLogging(logging =>
                {


                    logging.ClearProviders();
                    logging.AddConsole();
                    logging.AddDebug();

                    /// Apenas um plus =)
                    logging.AddEventLog();
                    logging.AddEventSourceLogger();

                });
    }
}
