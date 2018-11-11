using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HelloMVC.Models;
using Microsoft.Extensions.Configuration;

namespace HelloMVC.Controllers
{
    public class HomeController : Controller
    {
        private IConfiguration _configuration;
        public HomeController(IConfiguration Configuration) {
            _configuration = Configuration;
        }
        public IActionResult Index()
        {
            this.ViewData.Add("secret", _configuration.GetConnectionString("DefaultConnection")); // _configuration["Settings:setting02"]);
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "This is my first ASP.NET Core web application!";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
