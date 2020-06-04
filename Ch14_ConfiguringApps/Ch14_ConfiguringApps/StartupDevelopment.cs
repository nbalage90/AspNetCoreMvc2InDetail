using Ch14_ConfiguringApps.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ch14_ConfiguringApps
{
    /// <summary>
    /// When ASP.NET looks for the Startup class, it first checks to see whether there is a class
    /// whose name includes the current hosting environment.
    /// </summary>
    public class StartupDevelopment
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<UptimeService>();
            services.AddMvc() // EnableEndpointRouting set is required because of the UseMvcWithDefaultRoute()
                .AddMvcOptions(options =>
                {
                    options.EnableEndpointRouting = false;
                });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseBrowserLink();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}
