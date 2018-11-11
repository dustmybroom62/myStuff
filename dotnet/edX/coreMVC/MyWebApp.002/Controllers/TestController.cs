using System;
using Microsoft.AspNetCore.Mvc;

namespace MyWebApp.Controllers
{
    public class TestController : Controller
    {
        // Add actions here ...
        public IActionResult Foo()
        {
            ViewData["Title"] = "Foo";
            ViewData["Header"] = "Header Foo";
            ViewData["Items"] = "AAA BBB CCC".Split(' ');
            return View();
        }

        public IActionResult Bar()
        {
            ViewBag.Title = "Bar";
            ViewBag.Header = "Header Bar";
            ViewBag.Items = "DDD EEE FFF".Split(' ');
            return View();
        }
    }
}
