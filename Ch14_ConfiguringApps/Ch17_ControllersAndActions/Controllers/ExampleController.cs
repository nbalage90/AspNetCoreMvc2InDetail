using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ch17_ControllersAndActions.Controllers
{
    public class ExampleController : Controller
    {
        public JsonResult Index()
        {
            return Json(new[] { "Alice", "Bob", "Joe" });
        }

        public ContentResult Index2()
        {
            return Content("[\"Alice\"],[\"Bob\"],[\"Joe\"]", "application/json");
        }

        public ObjectResult Index3()
        {
            return Ok(new string[] { "Alice", "Bob", "Joe" });
        }

        public VirtualFileResult Index4() =>
            File("/lib/bootstrap/css/bootrstrap.css", "text/css");

        public StatusCodeResult Index5() => NotFound();
    }
}
