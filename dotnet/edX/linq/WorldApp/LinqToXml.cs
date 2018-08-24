using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;
using WorldApp.Models;

namespace WorldApp
{
    class LinqToXml
    {
        public static string folder = Path.Combine(Environment.CurrentDirectory, "..");

        public static void Execute()
        {
            FirstElementOfList();
            //QueryXmlDataFiles();
            //GenerateXmlDataFiles();
        }

        private static void FirstElementOfList()
        {
            var list = new List<int> {1, 2, 3, 4, 5};
            Console.WriteLine(list[0]);
            Console.WriteLine(list.First());
            Console.WriteLine(list.ElementAt(0));
            Console.WriteLine(list.Take(1).First());
        }

        private static void QueryXmlDataFiles()
        {
            var rootElement = XElement.Load(Path.Combine(folder, "world.xml"));

            // Query 1:
            var continents = rootElement.Elements()
                .Select(e => e.Attribute("name").Value);
            foreach (var item in continents)
            {
                System.Console.WriteLine(item);
            }

            // Query 2:
            var northAmericaPop = rootElement.Elements()
                .Single(e => e.Attribute("name").Value == "North America")
                .Descendants("country")
                .Sum(e => int.Parse(e.Attribute("population").Value));
            System.Console.WriteLine(northAmericaPop);
        }

        private static void GenerateXmlDataFiles()
        {
            // Read data
            var dbContext = new WorldContext();
            var continents = dbContext.Continent.Include(c => c.Country)
                    .ThenInclude(country => country.City);

            // Construct XML
            var rootElement = new XElement("world");
            foreach (var continent in continents)
            {
                var continentElement = new XElement("continent");
                continentElement.Add(new XAttribute("name", continent.Name));
                foreach (var country in continent.Country)
                {
                    var countryElement = new XElement("country");
                    countryElement.Add(new XAttribute("code", country.Code));
                    countryElement.Add(new XAttribute("name", country.Name));
                    countryElement.Add(new XAttribute("area", country.SurfaceArea));
                    countryElement.Add(new XAttribute("population", country.Population));
                    foreach (var city in country.City)
                    {
                        var cityElement = new XElement("city");
                        cityElement.Add(new XAttribute("id", city.Id));
                        cityElement.Add(new XAttribute("name", city.Name));
                        cityElement.Add(new XAttribute("population", city.Population));
                        countryElement.Add(cityElement);
                    }
                    continentElement.Add(countryElement);
                }
                rootElement.Add(continentElement);
            }

            // Persist in-memory XML data to XML file
            var writer = XmlWriter.Create(Path.Combine(folder, "world.xml"));
            rootElement.WriteTo(writer);
            writer.Flush();
            writer.Close();
            System.Console.WriteLine("DONE!");
        }
    }
}