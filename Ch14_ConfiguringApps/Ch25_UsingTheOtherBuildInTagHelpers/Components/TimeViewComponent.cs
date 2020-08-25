using Microsoft.AspNetCore.Mvc;
using System;

namespace Ch25_UsingTheOtherBuildInTagHelpers.Components
{
    public class TimeViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(DateTime.Now);
        }
    }
}
