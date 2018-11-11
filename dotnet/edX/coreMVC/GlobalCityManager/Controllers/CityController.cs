using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GlobalCityManager.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GlobalCityManager.Controllers
{
    public class CityController : Controller
    {
        private globalContext dbContext;
        private readonly IHostingEnvironment _hostingEnvironment;
        public CityController(globalContext dbCtx, IHostingEnvironment hostingEnvironment)
        {
            dbContext = dbCtx;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            IEnumerable<City> cities = dbContext.City;
            return View(cities);
        }

        [HttpGet]
        public IActionResult Create()
        {
            IQueryable<SelectListItem> query = GetCountrySelectList();
            CityEdit cityEdit = new CityEdit()
            {
                lstCountry = query.AsEnumerable()
            };
            return View(cityEdit);
        }

        private IQueryable<SelectListItem> GetCountrySelectList()
        {
            return dbContext.Country.Select(c => new SelectListItem
            {
                Value = c.Code.ToString(),
                Text = c.Name,
                Selected = false
            });
        }

        [HttpPost]
        public IActionResult Create(CityEdit city)
        {
            if (!ModelState.IsValid)
            {
                IQueryable<SelectListItem> query = GetCountrySelectList();
                city.lstCountry = query.AsEnumerable();
                return View(city);
            }
            dbContext.City.Add(city);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id) {
            City city = dbContext.City.Find(id);
            if (null == city) {
                return RedirectToAction("Index");
            }
            var query = dbContext.Country.Select(c => new SelectListItem
            {
                Value = c.Code.ToString(),
                Text = c.Name,
                Selected = c.Code == city.CountryCode
            });
            CityEdit cityEdit = new CityEdit() {
                lstCountry = query.AsEnumerable(),
                Id = city.Id,
                Name = city.Name,
                District = city.District,
                Population = city.Population
            };
            cityEdit.lstCountry = query.AsEnumerable();
            return View(cityEdit);
        }

        [HttpPost]
        public IActionResult Update(City city) {
            if (!ModelState.IsValid) {
                return View(city);
            }
            City cityUp = dbContext.City.Find(city.Id);
            if (null == cityUp) {
                return RedirectToAction("Index");
            }
            cityUp.CountryCode = city.CountryCode;
            cityUp.District = city.District;
            cityUp.Name = city.Name;
            cityUp.Population = city.Population;
            dbContext.Entry(cityUp).State = EntityState.Modified;
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id) {
            City city = dbContext.City.Find(id);
            if (null != city) {
                dbContext.City.Remove(city);
                dbContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
