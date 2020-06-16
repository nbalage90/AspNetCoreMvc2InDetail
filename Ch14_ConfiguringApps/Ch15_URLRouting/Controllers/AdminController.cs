using Ch15_URLRouting.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ch15_URLRouting.Controllers
{
    public class AdminController : Controller
    {
        public ViewResult Index() =>
            View("Result", new Result
            {
                Controller = nameof(AdminController),
                Action = nameof(Index)
            });
    }
}
