using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ch17_ControllersAndActions.Controllers
{
    public class DerivedController : Controller
    {
        public ViewResult Index() =>
            View("Result", $"This is a derived controller");

        public ViewResult Headers() => View("DictionaryResult",
            Request.Headers.ToDictionary(kvp => kvp.Key, kvp => kvp.Value.First()));
    }
}
