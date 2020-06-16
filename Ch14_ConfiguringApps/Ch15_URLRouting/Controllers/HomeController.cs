using Ch15_URLRouting.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ch15_URLRouting.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index() =>
            View("Result", new Result
            {
                Controller = nameof(HomeController),
                Action = nameof(Index)
            });

        public ViewResult CustomVariable(string id)
        {
            Result r = new Result
            {
                Controller = nameof(HomeController),
                Action = nameof(CustomerController)
            };
            //r.Data["Id"] = RouteData.Values["id"];
            r.Data["Id"] = id ?? "<no value>";
            return View("Result", r);
        }
    }
}
