using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorldWebServer.Models;

namespace WorldWebServer.Controllers {
    [Route("api/[controller]")]
    public class CitiesController : Controller {
        private WorldDbContext worldDbContext;

        public CitiesController() {
            worldDbContext = WorldDbContextFactory.Create();
        }

        [HttpGet]
        public ActionResult Get() {
            var cities = worldDbContext.City.ToArray();
            if (null == cities || 0 == cities.Length) {
                return NotFound();
            }
            return Ok(cities);
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id) {
            var city = worldDbContext.City.SingleOrDefault(c => c.ID == id);
            if (null == city) {
                return NotFound();
            }
            return Ok(city);
        }

        [HttpGet("cc/{cc}")]
        public ActionResult GetCityByCountryCode( string cc) {
            var cities = worldDbContext.City.Where(c => c.CountryCode == cc);
            if (0 == cities.Count()) {
                return NotFound();
            }
            return Ok(cities);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id) {
            var city = worldDbContext.City.SingleOrDefault(c => c.ID == id);
            if (null == city) {
                return NotFound();
            }
            worldDbContext.City.Remove(city);
            worldDbContext.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public ActionResult Post([FromBody] City city) {
            if (!ModelState.IsValid) {
                return BadRequest();
            }
            worldDbContext.City.Add(city);
            worldDbContext.SaveChanges();
            return Created($"api/cities/{city.ID}", city);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] City cityIn) {
            var city = worldDbContext.City.SingleOrDefault(c => c.ID == id);
            if (null == city) {
                return NotFound();
            }
            worldDbContext.Entry(city).CurrentValues.SetValues(cityIn);
            // city.Name = cityIn.Name;
            // city.CountryCode = cityIn.CountryCode;
            // city.District = cityIn.District;
            // city.Population = cityIn.Population;
            worldDbContext.Entry(city).State = EntityState.Modified;
            worldDbContext.SaveChanges();
            return Ok();
        }
    }
}