using System.Collections.Generic;

namespace GlobalCityManager.Models {
    public class CountryDetail : Country {
        public IEnumerable<City> CityList;
    }
}