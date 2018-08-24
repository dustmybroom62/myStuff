using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ConsoleTables;
using Microsoft.EntityFrameworkCore;
using MovieApp.Entities;
using MovieApp.Extensions;
using MovieApp.Models;

namespace MovieApp
{
    public static class Module2Helper
    {
        public static void SelfAssessment()
        {
            Console.WriteLine(nameof(SelfAssessment));
            Console.WriteLine("Enter a page size:");
            var pageSize = Math.Max(1, Console.ReadLine().ToInt());

            Console.WriteLine("Enter a page number:");
            var pageNumber = Math.Max(1, Console.ReadLine().ToInt());

            Console.WriteLine("Enter a sort column (default Last Name):");
            Console.WriteLine("\ti - Actor ID");
            Console.WriteLine("\tf - First Name");
            Console.WriteLine("\tl - Last Name");
            var key = Console.ReadKey();

            Console.WriteLine();

            Console.WriteLine("Sort Order (default ascending):");
            Console.WriteLine("\ta - Ascending");
            Console.WriteLine("\td - Descending");
            var sort = Console.ReadKey();
            Console.WriteLine();


            var skip = (pageNumber - 1) * pageSize;

            var actors = ActorsGet(pageSize, key, sort, skip);
            ConsoleTable.From(actors).Write();
        }

        private static IEnumerable<ActorModel> ActorsGet(int pageSize, ConsoleKeyInfo key, ConsoleKeyInfo sort, int skip)
        {
            switch (sort.Key)
            {
                case ConsoleKey.D:
                    return MoviesContext.Instance.Actors
                        .OrderByDescending(GetSortActor(key))
                        .Skip(skip)
                        .Take(pageSize)
                        .Select(a => a.Copy<Actor, ActorModel>());
                default:
                    return MoviesContext.Instance.Actors
                        .OrderBy(GetSortActor(key))
                        .Skip(skip)
                        .Take(pageSize)
                        .Select(a => a.Copy<Actor, ActorModel>());
            }
        }

        public static void CompositeKeys()
        {
            var data = new[] {
                new FilmInfo { Title = "Thor", ReleaseYear = 2011, Rating = "PG-13" },
                new FilmInfo { Title = "The Avengers", ReleaseYear = 2012, Rating = "PG-13" },
                new FilmInfo { Title = "Rogue One", ReleaseYear = 2016, Rating = "PG-13" }
            };

            MoviesContext.Instance.FilmInfos.AddRange(data);
            MoviesContext.Instance.SaveChanges();

            var infos = MoviesContext.Instance.FilmInfos;
            ConsoleTable.From(infos).Write();
        }

        public static void MigrationAddTable()
        {
            var user = new ApplicationUser
            {
                UserName = "testuser",
                InvalidLoginAttempts = 0
            };

            MoviesContext.Instance.ApplicationUsers.Add(user);
            MoviesContext.Instance.SaveChanges();

            var users = MoviesContext.Instance.ApplicationUsers;
            ConsoleTable.From(users).Write();
        }

        public static void MigrationAddColumn()
        {
            var film = MoviesContext.Instance.Films
                            .FirstOrDefault(f => f.Title.Contains("the first avenger"));
            if (film != null)
            {
                Console.WriteLine($"Updating film with id {film.FilmId}");
                film.Runtime = 124;
                MoviesContext.Instance.SaveChanges();
            }

            var films = MoviesContext.Instance.Films
                            .Select(f => f.Copy<Film, FilmModel>());
            ConsoleTable.From(films).Write();
        }

        public static void LinqBasics()
        {
            var search = "ar";
            var actors = (from a in MoviesContext.Instance.Actors
                          where a.FirstName.Contains(search)
                          orderby a.FirstName descending
                          select a.Copy<Actor, ActorModel>());
            ConsoleTable.From(actors).Write();
        }

        public static void LambdaBasics()
        {
            var search = "g";
            var films = MoviesContext.Instance.Films
                        .Where(f => f.Title.Contains(search))
                        .OrderByDescending(f => f.Title)
                        .Select(f => f.Copy<Film, FilmModel>());
            ConsoleTable.From(films).Write();
        }

        public static void LinqVsLambda()
        {
            //groupingLinqVsLambda();
            joinLinqVsLambda();
        }

        private static void joinLinqVsLambda()
        {
            var ratings = new[] {
                new { Code = "G", Name = "General Audiences"},
                new { Code = "PG", Name = "Parental Guidance Suggested"},
                new { Code = "PG-13", Name = "Parents Strongly Cautioned"},
                new { Code = "R", Name = "Restricted"},
            };

            var films = (from f in MoviesContext.Instance.Films
                         join r in ratings on f.RatingCode equals r.Code
                         select new { f.Title, r.Code, r.Name });
            ConsoleTable.From(films).Write();

            films = MoviesContext.Instance.Films.Join(ratings,
                        f => f.RatingCode,
                        r => r.Code,
                        (f, r) => new { f.Title, r.Code, r.Name });
            ConsoleTable.From(films).Write();
        }

        private static void groupingLinqVsLambda()
        {
            var filmGroups = (from f in MoviesContext.Instance.Films
                              group f by f.RatingCode into g
                              select g);
            foreach (var filmGroup in filmGroups)
            {
                Console.WriteLine(filmGroup.Key);
                foreach (var film in filmGroup.OrderBy(f => f.Title))
                {
                    Console.WriteLine($"\t{film.Title}");
                }
            }

            Console.WriteLine();
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine();

            filmGroups = MoviesContext.Instance.Films
                            .GroupBy(f => f.RatingCode);
            foreach (var filmGroup in filmGroups)
            {
                Console.WriteLine(filmGroup.Key);
                foreach (var film in filmGroup.OrderBy(f => f.Title))
                {
                    Console.WriteLine($"\t{film.Title}");
                }
            }
        }

        public static void Sort()
        {
            var actors = MoviesContext.Instance.Actors
                            .OrderBy(a => a.LastName)
                            .Select(a => a.Copy<Actor, ActorModel>());
            ConsoleTable.From(actors).Write();

            var films = MoviesContext.Instance.Films
                            .OrderBy(f => f.RatingCode)
                            .ThenBy(f => f.ReleaseYear)
                            .ThenBy(f => f.Title)
                            .Select(f => f.Copy<Film, FilmModel>());
            ConsoleTable.From(films).Write();
        }
        public static void SortDescending()
        {
            var actors = MoviesContext.Instance.Actors
                .OrderByDescending(a => a.FirstName)
                .Select(a => a.Copy<Actor, ActorModel>());
            ConsoleTable.From(actors).Write();

            var films = MoviesContext.Instance.Films
                .OrderByDescending(f => f.RatingCode)
                .ThenBy(f => f.Title)
                .Select(f => f.Copy<Film, FilmModel>());
            ConsoleTable.From(films).Write();
        }
        public static void Skip()
        {
            var films = MoviesContext.Instance.Films
                .OrderBy(f => f.Title)
                .Skip(3)
                .Select(f => f.Copy<Film, FilmModel>());
            ConsoleTable.From(films).Write();
        }
        public static void Take()
        {
            var films = MoviesContext.Instance.Films
                .OrderBy(f => f.Title)
                .Take(5)
                .Select(f => f.Copy<Film, FilmModel>());
            ConsoleTable.From(films).Write();
        }
        public static void Paging()
        {
            Console.WriteLine("Enter a page size:");
            var pageSize = Math.Max(1, Console.ReadLine().ToInt());

            Console.WriteLine("Enter a page number:");
            var pageNumber = Math.Max(1, Console.ReadLine().ToInt());

            Console.WriteLine("Enter a sort column:");
            Console.WriteLine("\ti - Film ID");
            Console.WriteLine("\tt - Title");
            Console.WriteLine("\ty - Year");
            Console.WriteLine("\tr - Rating");
            var key = Console.ReadKey();

            Console.WriteLine();

            // var pageSize = 5;
            // var pageNumber = 2;
            var skip = (pageNumber - 1) * pageSize;
            var films = MoviesContext.Instance.Films
                .OrderBy(GetSortFilm(key))
                //.OrderBy(f => f.Title)
                .Skip(skip)
                .Take(pageSize)
                .Select(f => f.Copy<Film, FilmModel>());
            ConsoleTable.From(films).Write();
        }

        private static Expression<Func<Actor, object>> GetSortActor(ConsoleKeyInfo info)
        {
            switch (info.Key)
            {
                case ConsoleKey.I:
                    return a => a.ActorId;
                case ConsoleKey.F:
                    return a => a.FirstName;
                case ConsoleKey.L:
                default:
                    return a => a.LastName;
            }
        }

        private static Expression<Func<Film, object>> GetSortFilm(ConsoleKeyInfo info)
        {
            switch (info.Key)
            {
                case ConsoleKey.I:
                    return f => f.FilmId;
                case ConsoleKey.Y:
                    return f => f.ReleaseYear;
                case ConsoleKey.R:
                    return f => f.RatingCode;
                default:
                    return f => f.Title;
            }
        }
    }
}