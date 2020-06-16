using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ch15_URLRouting.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Ch15_URLRouting
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<RouteOptions>(options =>
                options.ConstraintMap.Add("weekday", typeof(WeekDayContraint)));
            services.AddMvc(options => options.EnableEndpointRouting = false);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "MyRoute",
            //    //  template: "{controller:regex(^H.*)=Home}/{action:regex(^Index|^About$)=Index}/{id?}");

            //    //  template: "{controller=Home}/{action=Index}/{id:range(10, 20)?}");

            //        template: "{controller}/{action}/{id:weekday?}");
            //    //routes.MapRoute(
            //    //    name: "MyRoute2",
            //    //    template: "{controller}/{action}/{id?}",
            //    //    defaults: new { controller = "Home", action = "Index" },
            //    //    constraints: new { id = new IntRouteConstraint() });

            //    //routes.MapRoute(
            //    //    name: "MyRoute",
            //    //    template: "{controller=Home}/{action=Index}/{id?}/{*catchall}"); // catchall: variable segment, it could be i.e: Delete/Perm

            //    //routes.MapRoute(
            //    //    name: "ShopSchema2",
            //    //    template: "Shop/OldAction",
            //    //    defaults: new { controller = "Home", action = "Index" });

            //    //routes.MapRoute(
            //    //    name: "ShopSchema",
            //    //    template: "Shop/{action}",
            //    //    defaults: new { controller = "Home" });

            //    //routes.MapRoute("", "X{controller}/{action}");

            //    //routes.MapRoute(
            //    //    name: "default", 
            //    //    template: "{controller=Home}/{action=Index}");

            //    //routes.MapRoute(
            //    //    name: "",
            //    //    template: "Public/{controller=Home}/{action=Index}");
            //});
        }
    }
}
