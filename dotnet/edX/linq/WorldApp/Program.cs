using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WorldApp.Models;

namespace WorldApp
{
    class Program
    {
        static void Main(string[] args)
        {
            LinqToXml.Execute();
            
            //var dbContext = new WorldContext();

            //JoinOperations(dbContext);
            //GroupingOperations(dbContext);
            //AggregationOperations(dbContext);
            //DataTypeConversion(dbContext);
            //PartitioningOperations(dbContext);
            //SingleElementOperations(dbContext);
            //SortingOperations(dbContext);
            //SetAndConcatenationOperations(dbContext);
            //ProjectionOperations(dbContext);
            //QuantifierOperations(dbContext);
            //FilteringData(dbContext);
        }

        private static void JoinOperations(WorldContext dbContext)
        {
            var continents = dbContext.Continent.OrderBy(c => c.Name);
            var countries = dbContext.Country.OrderBy(c => c.Name);

            #region GroupJoin
            // Join then GroupBy
            var result = from ctn in continents
                         join ctry in countries
                         on ctn.Id equals ctry.ContinentId
                         group ctry by ctn.Name into g
                         select new { Continent = g.Key, CountryCount = g.Count() };

            // GroupJoin
            // var result = from ctn in continents
            //              join ctry in countries
            //              on ctn.Id equals ctry.ContinentId into g
            //              select new { Continent = ctn.Name, CountryCount = g.Count() };

            // var result = continents.GroupJoin(countries,
            //     ctn => ctn.Id, ctry => ctry.ContinentId,
            //     (ctn, g) => new { Continent = ctn.Name, CountryCount = g.Count() }
            // );

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Continent}: {item.CountryCount}");
            }
            #endregion

            #region Join
            // var result = from ctn in continents
            //              join ctry in countries
            //              on ctn.Id equals ctry.ContinentId
            //              select new { Continent = ctn.Name, Country = ctry.Name };

            // // var result = continents.Join(countries,
            // //     c => c.Id, c => c.ContinentId,
            // //     (cont, coun) => new { Continent = cont.Name, Country = coun.Name });

            // foreach (var item in result)
            // {
            //     Console.WriteLine($"{item.Continent}\t {item.Country}");
            // }
            #endregion
        }

        private static void GroupingOperations(WorldContext dbContext)
        {
            var countries = dbContext.Country
                .Include(c => c.Continent)
                .OrderByDescending(c => c.SurfaceArea);

            var result = from c in countries
                         group c.Name by c.Continent.Name into g
                         select $"{g.Key}: {string.Join(",", g.Take(3))}";

            // var result = countries.GroupBy(c => c.Continent.Name, c => c.Name)
            //     .Select(g => $"{g.Key}: {string.Join(",", g.Take(3))}");

            foreach (var r in result)
            {
                Console.WriteLine(r);
            }
        }

        private static void AggregationOperations(WorldContext dbContext)
        {
            var countries = dbContext.Country
                .Include(c => c.Continent);

            var europe = countries.Where(c => c.Continent.Name == "Europe");
            var largest = europe.Max(e => e.SurfaceArea);
            var smallest = europe.Min(e => e.SurfaceArea);
            var howMany = europe.Count();
            var euPopulation = europe.Sum(c => c.Population);

            Console.WriteLine($"largest = {largest}");
            Console.WriteLine($"smallest = {smallest}");
            Console.WriteLine($"howMany = {howMany}");
            Console.WriteLine($"euPopulation = {euPopulation}");
        }

        private static void DataTypeConversion(WorldContext dbContext)
        {
            var array = dbContext.Continent.ToArray();
            var list = dbContext.Continent.ToList();
            var dict = dbContext.Country.ToDictionary(c => c.Name, c => c.Population);
            var lookup = dbContext.Country.Include(nameof(Country.Continent))
                .ToLookup(c => c.Continent.Name, c => c.Name);

            Console.WriteLine(array.Length);
            Console.WriteLine(list.Count);
            Console.WriteLine(dict["China"]);
            Console.WriteLine(string.Join(",", lookup["Antarctica"]));
        }

        private static void PartitioningOperations(WorldContext dbContext)
        {
            var sorted = dbContext.Country.OrderByDescending(c => c.SurfaceArea);
            var large5 = sorted.Take(5);
            var large21to25 = sorted.Skip(20).Take(5);
            var small5 = sorted.Skip(sorted.Count() - 5).Take(5); //Pomelo library does not support TakeLast
            //var small5 = sorted.ToList().TakeLast(5); //Pomelo library does not support TakeLast

            Console.WriteLine("Largest 5");
            Console.WriteLine(new string('=', 78));
            foreach (var c in large5)
            {
                Console.WriteLine(c.Name);
            }
            Console.WriteLine("\nlarge21to25");
            Console.WriteLine(new string('=', 78));
            foreach (var c in large21to25)
            {
                Console.WriteLine(c.Name);
            }
            Console.WriteLine("\nsmall5");
            Console.WriteLine(new string('=', 78));
            foreach (var c in small5)
            {
                Console.WriteLine(c.Name);
            }
        }

        private static void SingleElementOperations(WorldContext dbContext)
        {
            var sorted = dbContext.Country.OrderByDescending(c => c.SurfaceArea);
            var largest = sorted.First();
            var smallest = sorted.Last();
            var thirdLargest = sorted.ToList().ElementAt(2); // must use ToList() here due to Pomelo limited implementation
            Console.WriteLine($"largest: {largest.Name} \t smallest: {smallest.Name} \t thirdLargest: {thirdLargest.Name}");
        }

        private static void SortingOperations(WorldContext dbContext)
        {
            var countries =
                from c in dbContext.Country.Include(c => c.Continent) //nameof(Country.Continent))
                orderby c.Continent.Name, c.Population descending
                select c;

            // var countries = dbContext.Country
            //     .Include(c => c.Continent)
            //     .OrderBy(c => c.Continent.Name)
            //     .ThenByDescending(c => c.Population);

            Console.WriteLine($"Continent\tCountry\tPopulation");
            Console.WriteLine(new string('=', 78));
            foreach (var c in countries)
            {
                Console.WriteLine($"{c.Continent.Name}\t{c.Name}\t{c.Population}");
            }
        }

        private static void SetAndConcatenationOperations(WorldContext dbContext)
        {
            var continents = dbContext.Continent
                  .Include(nameof(Continent.Country))
                  .Where(c => c.Country.Any());

            // var continents = dbContext.Country
            //     .Include(c => c.Continent)
            //     .Select(c => c.Continent)
            //     .Distinct();

            foreach (var c in continents)
            {
                Console.WriteLine(c.Name);
            }

            // var bigArea = dbContext.Country
            //     .OrderByDescending(c => c.SurfaceArea).Take(10);
            // var bigPopulation = dbContext.Country
            //     .OrderByDescending(c => c.Population).Take(10);

            // var r1 = bigArea.Union(bigPopulation);
            // var r2 = bigArea.Intersect(bigPopulation);
            // var r3 = bigArea.Except(bigPopulation);

            // Console.WriteLine("[Big Area or Big Population]");
            // foreach (var r in r1) {
            //     Console.WriteLine(r.Name);
            // }

            // Console.WriteLine("========================");
            // Console.WriteLine("[Big Area and Big Population]");
            // foreach (var r in r2) {
            //     Console.WriteLine(r.Name);
            // }

            // Console.WriteLine("========================");
            // Console.WriteLine("[Big Area but Not Big Population]");
            // foreach (var r in r3) {
            //     Console.WriteLine(r.Name);
            // }
        }

        private static void ProjectionOperations(WorldContext dbContext)
        {
            var names = dbContext.Country
                .Include(c => c.Continent)
                .Where(c => c.Continent.Name == "North America"
                || c.Continent.Name == "South America")
                .Select(c => c.Name);
            // var names = dbContext.Continent
            //     .Include(c => c.Country)
            //     .Where(c => c.Name == "North America" || c.Name == "South America")
            //     .SelectMany(c => c.Country)
            //     .Select(c => c.Name);

            // var names = from c in dbContext.Country
            //     where c.Population > 100000000// 1000000000
            //     select c.Name;

            // var names = dbContext.Country
            //     .Where(c => c.Population > 100000000)// 1000000000)
            //     .Select(c => c.Name);
            //Console.WriteLine("Countries with Population > 1B");
            Console.WriteLine(new string('-', 78));
            foreach (var item in names)
            {
                Console.WriteLine(item);
            }
        }

        class CityComparer : IEqualityComparer<City>
        {
            public bool Equals(City x, City y)
            {
                if (x.Name != y.Name)
                    return false;
                if (x.District != y.District)
                    return false;
                return true;
            }

            public int GetHashCode(City obj)
            {
                return obj.GetHashCode();
            }
        }

        private static void QuantifierOperations(WorldContext dbContext)
        {
            var seattle = new City
            {
                Name = "Seattle",
                District = "Washington"
            };
            // 2 examples: 1- using Any(), 2- using Contains()
            // #2 needs the IEqualityComparer for custom compare
            // #2 also needs City.ToList() due to Pomelo MySql driver not fully implemented Contains using custom compare...
            // at the time of this writing.
            bool bContainsCity = dbContext.City
                .Any(c => c.Name == seattle.Name && c.District == seattle.District);
            // bool bContainsCity = dbContext.City.ToList()
            //     .Contains(
            //         seattle,
            //         new CityComparer()
            // );
            Console.WriteLine($"Seattle, Washington exists == {bContainsCity}");

            bool bAnyContinent = dbContext.Continent.Any();
            Console.WriteLine($"Any Continent data == {bAnyContinent}");

            bool bAnyCity = dbContext.City.Any(c => c.Population > 10000000);
            Console.WriteLine($"Any City population > 10M == {bAnyCity}");

            bool bAllCities = dbContext.City.All(c => c.Population > 1000);
            Console.WriteLine($"All cities.Population > 1000 == {bAllCities}");
        }

        private static void FilteringData(WorldContext dbContext)
        {
            var countries = from c in dbContext.Country
                            where c.Population > 100000000
                            select c;
            //var countries = dbContext.Country.Where(c => c.Population > 100000000);
            foreach (var c in countries)
            {
                Console.WriteLine($"{c.Name} => {c.Population}");
            }
        }
    }
}
