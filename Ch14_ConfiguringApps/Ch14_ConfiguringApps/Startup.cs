using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ch14_ConfiguringApps.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Ch14_ConfiguringApps
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<UptimeService>();
            services.AddMvc(options => options.EnableEndpointRouting = false); // EnableEndpointRouting set is required because of the UseMvcWithDefaultRoute()
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ContentMiddleware>();
        }
    }
}
