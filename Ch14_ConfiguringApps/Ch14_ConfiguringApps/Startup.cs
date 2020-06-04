using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ch14_ConfiguringApps.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Ch14_ConfiguringApps
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<UptimeService>();
            services.AddMvc() // EnableEndpointRouting set is required because of the UseMvcWithDefaultRoute()
                .AddMvcOptions(options =>
                {
                    options.EnableEndpointRouting = false;
                    options.RespectBrowserAcceptHeader = true;
                });
        }

        public void ConfigureDevelopmentServices(IServiceCollection services)
        {
            services.AddSingleton<UptimeService>();
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            //if ((Configuration.GetSection("ShortCircuitMiddleware")?.GetValue<bool>("EnableBrowserShortCircuit")).Value)
            //{
            //    app.UseMiddleware<BrowserTypeMiddleware>();
            //    app.UseMiddleware<ShortCircuitMiddleware>();
            //}

            //if (env.IsDevelopment())
            //{
            //    //app.UseMiddleware<ErrorMiddleware>();
            //    //app.UseMiddleware<BrowserTypeMiddleware>();
            //    //app.UseMiddleware<ShortCircuitMiddleware>();
            //    //app.UseMiddleware<ContentMiddleware>();
            //    app.UseDeveloperExceptionPage();
            //    app.UseStatusCodePages();
            //    app.UseBrowserLink(); // it should not be added in staging or production; Microsoft.VisualStudio.Web.BrowserLink needed
            //}
        }

        public void ConfigureDevelopment(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseBrowserLink(); // it should not be added in staging or production; Microsoft.VisualStudio.Web.BrowserLink needed
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}
