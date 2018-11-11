using System;
using System.Linq;
using MovieApp.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MovieApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new MoviesContext();
            Console.WriteLine(context.Film.Count().ToString());
        }
    }
}
