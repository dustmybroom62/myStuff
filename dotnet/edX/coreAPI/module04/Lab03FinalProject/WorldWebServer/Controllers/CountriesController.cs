using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WorldWebServer.Models;

namespace WorldWebServer.Controllers {
    [Route("api/[controller]")]
    public class CountriesController : Controller {
        private WorldDbContext worldDbContext;

        public CountriesController() {
            worldDbContext = WorldDbContextFactory.Create();
        }

        [HttpGet]
        public ActionResult Get() {
            var countries = worldDbContext.Country.ToArray();
            if (null == countries || 0 == countries.Length) {
                return NotFound();
            }
            return Ok(countries);
        }
    }
}