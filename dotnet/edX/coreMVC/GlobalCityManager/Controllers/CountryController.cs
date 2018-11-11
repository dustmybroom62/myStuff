
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using GlobalCityManager.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GlobalCityManager.Controllers {
    public class CountryController : Controller {
        private globalContext dbContext;
        private readonly IHostingEnvironment _hostingEnvironment;
        public CountryController(globalContext dbCtx, IHostingEnvironment hostingEnvironment) {
            dbContext = dbCtx;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index() {
            IEnumerable<Country> countries = dbContext.Country.OrderBy(c => c.Name);
            return View(countries);
        }

        public IActionResult Detail(string id) {
            var c = dbContext.Country.Find(id);
            if (null == c) {
                return RedirectToAction("Index");
            }
            CountryDetail countryDetail = new CountryDetail() {
                Code = c.Code,
                Name = c.Name,
                Region = c.Region,
                NationalFlag = c.NationalFlag,
                CityList = dbContext.City.Where(y => y.CountryCode == c.Code)
            };
            return View(countryDetail);
        }

        [HttpGet]
        public IActionResult Create() {
            Country country = new Country() {
                NationalFlag = Country.DefaultFlagPath
            };
            return View(country);
        }

        [HttpPost]
        public IActionResult Create(Country country, IFormFile nationalFlagFile) {
            if (!ModelState.IsValid) {
                country.NationalFlag = Country.DefaultFlagPath;
                return View(country);
            }
            if (nationalFlagFile == null || nationalFlagFile.Length == 0) {
                country.NationalFlag = Country.DefaultFlagPath;
            } else {
                var targetFileName = $"{country.Code}{Path.GetExtension(nationalFlagFile.FileName)}";
                var relativeFilePath = Path.Combine("images", targetFileName);
                var absolutFilePath = Path.Combine(_hostingEnvironment.WebRootPath, relativeFilePath);
                country.NationalFlag = relativeFilePath;
                using (var stream = new FileStream(absolutFilePath, FileMode.Create))
                {
                    nationalFlagFile.CopyTo(stream);
                }
            }
            dbContext.Country.Add(country);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(string id) {
            Country country = dbContext.Country.Find(id);
            if (null == country) {
                return RedirectToAction("Index");
            }
            if (string.IsNullOrEmpty(country.NationalFlag)) {
                country.NationalFlag = Country.DefaultFlagPath;
            }
            return View(country);
        }

        [HttpPost]
        public IActionResult Update(Country country, IFormFile nationalFlagFile) {
            if (!ModelState.IsValid) {
                return View(country);
            }
            Country countryUp = dbContext.Country.Find(country.Code);
            if (null == countryUp) {
                return View(country);
            }
            if (nationalFlagFile == null || nationalFlagFile.Length == 0) {
                country.NationalFlag = Country.DefaultFlagPath;
            } else {
                var targetFileName = $"{country.Code}{Path.GetExtension(nationalFlagFile.FileName)}";
                var relativeFilePath = Path.Combine("images", targetFileName);
                var absolutFilePath = Path.Combine(_hostingEnvironment.WebRootPath, relativeFilePath);
                country.NationalFlag = relativeFilePath;
                using (var stream = new FileStream(absolutFilePath, FileMode.Create))
                {
                    nationalFlagFile.CopyTo(stream);
                }
            }
            countryUp.Name = country.Name;
            countryUp.Region = country.Region;
            countryUp.NationalFlag = country.NationalFlag;
            dbContext.Entry(countryUp).State = EntityState.Modified;
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Remove(string id) {
            Country country = dbContext.Country.Find(id);
            if (null != country) {
                dbContext.Country.Remove(country);
                dbContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}