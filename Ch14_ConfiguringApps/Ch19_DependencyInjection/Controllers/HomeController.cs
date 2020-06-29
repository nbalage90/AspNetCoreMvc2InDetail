using Ch18_DependencyInjection.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ch18_DependencyInjection.Controllers
{
    public class HomeController : Controller
    {
        private IRepository repository;
        private ProductTotalizer totalizer;

        public HomeController(IRepository repo, ProductTotalizer total)
        {
            repository = repo;
            totalizer = total;
        }

        public ViewResult Index([FromServices]ProductTotalizer totalizer)
        {
            //IRepository repository = HttpContext.RequestServices.GetService(IRepository);

            ViewBag.HomeController = repository.ToString();
            ViewBag.Totalizer = totalizer.Repository.ToString();
            return View(repository.Products);
        }
    }
}
