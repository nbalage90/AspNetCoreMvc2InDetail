using Ch14_ConfiguringApps.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ch14_ConfiguringApps.Controllers
{
    public class HomeController : Controller
    {
        private UptimeService uptime;
        private ILogger<HomeController> logger;

        public HomeController(UptimeService up, ILogger<HomeController> log)
        {
            uptime = up;
            logger = log;
        }

        public ViewResult Index(bool throwException = false)
        {
            logger.LogDebug($"Hanlded {Request.Path} at uptime {uptime.Uptime}");

            if (throwException)
            {
                throw new NullReferenceException();
            }
            return View(new Dictionary<string, string>
            {
                ["Message"] = "This is the Index action",
                ["Uptime"] = $"{uptime.Uptime}ms"
            });
        }

        public ViewResult Error() => View(nameof(Index),
            new Dictionary<string, string>
            {
                ["Message"] = "This is the Error action"
            });
    }
}
