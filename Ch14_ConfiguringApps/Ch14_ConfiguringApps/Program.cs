using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Reflection;
using System.IO;

namespace Ch14_ConfiguringApps
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        //public static IWebHost CreateHostBuilder(string[] args)
        //{
        //    return new WebHostBuilder()
        //        .UseKestrel() // configures the Kestrel
        //        .UseContentRoot(Directory.GetCurrentDirectory()) // configures the root directory of the application
        //        //.ConfigureAppConfiguration((hostingcontext, config) => // prepares the configuration data for the application
        //        //{
        //        //    var env = hostingcontext.HostingEnvironment;
        //        //    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        //        //          .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);

        //        //    if (env.IsDevelopment())
        //        //    {
        //        //        var appAssembly = Assembly.Load(new AssemblyName(env.ApplicationName));
        //        //        if (appAssembly != null)
        //        //        {
        //        //            config.AddUserSecrets(appAssembly, optional: true); // used to store sensitive data outside of code files
        //        //        }
        //        //    }

        //        //    config.AddEnvironmentVariables();

        //        //    if (args != null)
        //        //    {
        //        //        config.AddCommandLine(args);
        //        //    }
        //        //})
        //        //.ConfigureLogging((hostingContext, logging) =>
        //        //{
        //        //    logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
        //        //    logging.AddConsole();
        //        //    logging.AddDebug();
        //        //})
        //        .UseIISIntegration()
        //        //.UseDefaultServiceProvider((context, options) => // used to configure dependency injection
        //        //{
        //        //    options.ValidateScopes = context.HostingEnvironment.IsDevelopment();
        //        //})
        //        .UseStartup<Startup>()
        //        .Build();
        //}
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>()
                    .UseDefaultServiceProvider(options =>
                        options.ValidateScopes = false);
                });
    }  
}
