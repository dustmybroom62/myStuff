using System;
using MyApp.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var dbContext = new sakilaContext();
            // var uTarget = dbContext.City.SingleOrDefault(c => c.CityId == 1001);
            // if (null != uTarget) {
            //     // dbContext.Remove(uTarget); //delete record
            //     // uTarget.City1 = "Kirkland"; //update record
            //     // dbContext.Update(uTarget); //update record
            //     dbContext.SaveChanges();
            // }
            // display all films with the actors listed below
            // var city = new City() {CityId = 1001, City1 = "Redmond", CountryId = 103};
            // dbContext.Add(city);
            // dbContext.SaveChanges();
            // var records = dbContext.Film.Include(f => f.FilmActor).ThenInclude(r => r.Actor).ToList();
            // foreach (var record in records)
            // {
            //     System.Console.WriteLine($"Film: {record.Title}");
            //     var counter = 1;
            //     foreach (var fa in record.FilmActor)
            //     {
            //         System.Console.WriteLine($"\tActor {counter++}: {fa.Actor.FirstName} {fa.Actor.LastName}");
            //     }
            // }
        }
    }
}
