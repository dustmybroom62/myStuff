using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GlobalCityManager.Models {
    public class CityEdit : City {
        public IEnumerable<SelectListItem> lstCountry;
    }
}