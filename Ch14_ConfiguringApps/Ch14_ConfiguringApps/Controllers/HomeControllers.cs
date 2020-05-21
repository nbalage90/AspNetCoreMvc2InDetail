using Ch14_ConfiguringApps.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ch14_ConfiguringApps.Controllers
{
    public class HomeControllers : Controller
    {
        private UptimeService uptime;

        public HomeControllers(UptimeService up) => uptime = up;

        public ViewResult Index() => View(new Dictionary<string, string>
        {
            ["Message"] = "This is the Index action",
            ["Uptime"] = $"{uptime.Uptime}ms"
        });
    }
}
