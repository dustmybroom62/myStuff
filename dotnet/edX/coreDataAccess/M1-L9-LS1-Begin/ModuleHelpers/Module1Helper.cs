using System;
using System.Linq;
using ConsoleTables;
using MovieApp.Entities;
using MovieApp.Extensions;
using MovieApp.Models;

namespace MovieApp
{
    public static class Module1Helper
    {
        internal static void SelectList()
        {
            var actors = MoviesContext.Instance.Actors.Select(a => a.Copy<Actor, ActorModel>());
            ConsoleTable.From(actors).Write();

            var films = MoviesContext.Instance.Films.Select(f => f.Copy<Film, FilmModel>());
            ConsoleTable.From(films).Write();
        }

        internal static void SelectById()
        {
            Console.WriteLine("Enter an Actor ID");
            var actorId = Console.ReadLine().ToInt();
            var actor = MoviesContext.Instance.Actors.SingleOrDefault(a => a.ActorId == actorId);

            if (actor == null)
            {
                Console.WriteLine($"Actor with ID {actorId} not found.");
            }
            else
            {
                Console.WriteLine($"ID: {actor.ActorId}  Name: {actor.FirstName} {actor.LastName}");
            }

            Console.WriteLine("Enter a Film Title");
            var title = Console.ReadLine();
            var film = MoviesContext.Instance.Films.FirstOrDefault(f => f.Title.Contains(title));
            if (film == null)
            {
                Console.WriteLine($"Film with Title {title} not found.");
            }
            else
            {
                Console.WriteLine($"ID: {film.FilmId}  Title: {film.Title}  Year: {film.ReleaseYear}  Rating: {film.RatingCode}");
            }

        }

        internal static void CreateItem()
        {
            Console.WriteLine("Add an Actor");

            Console.WriteLine("Enter a First Name");
            var firstName = Console.ReadLine();

            Console.WriteLine("Enter a Last Name");
            var lastName = Console.ReadLine();

            var actor = new Actor { FirstName = firstName, LastName = lastName };

            MoviesContext.Instance.Actors.Add(actor);

            MoviesContext.Instance.SaveChanges();

            var actors = MoviesContext.Instance.Actors
                               .Where(a => a.ActorId == actor.ActorId)
                               .Select(a => a.Copy<Actor, ActorModel>());
            ConsoleTable.From(actors).Write();

            // add film
            Console.WriteLine("Add a Film");

            Console.WriteLine("Enter a Title");
            var title = Console.ReadLine();

            Console.WriteLine("Enter a Description");
            var description = Console.ReadLine();

            Console.WriteLine("Enter a Release Year");
            var year = Console.ReadLine().ToInt();

            Console.WriteLine("Enter a Rating");
            var rating = Console.ReadLine();

            var film = new Film { Title = title, Description = description, ReleaseYear = year, RatingCode = rating };

            MoviesContext.Instance.Films.Add(film);

            MoviesContext.Instance.SaveChanges();

            var films = MoviesContext.Instance.Films
                            .Where(f => f.FilmId == film.FilmId)
                            .Select(f => f.Copy<Film, FilmModel>());
            ConsoleTable.From(films).Write();

        }

        internal static void UpdateItem()
        {
            Console.WriteLine("Update an Actor");

            Console.WriteLine("Enter an Actor ID");
            var actorId = Console.ReadLine().ToInt();

            var actor = MoviesContext.Instance.Actors
                            .SingleOrDefault(a => a.ActorId == actorId);
            if (actor == null)
            {
                Console.WriteLine($"Actor with id {actorId} not found");
            }
            else
            {
                ConsoleTable.From(new[] { actor.Copy<Actor, ActorModel>() })
                            .Write();

                Console.WriteLine("Enter the First Name");
                var firstName = Console.ReadLine().Trim();

                Console.WriteLine("Enter the Last Name");
                var lastName = Console.ReadLine().Trim();

                actor.FirstName = firstName;
                actor.LastName = lastName;

                MoviesContext.Instance.SaveChanges();

                var actors = MoviesContext.Instance.Actors
                                .Where(a => a.ActorId == actorId)
                                .Select(a => a.Copy<Actor, ActorModel>());
                ConsoleTable.From(actors).Write();
            }

            Console.WriteLine("Update a Film");

            Console.WriteLine("Enter a Film ID");
            var filmId = Console.ReadLine().ToInt();

            var film = MoviesContext.Instance.Films
                            .SingleOrDefault(a => a.FilmId == filmId);
            if (film == null)
            {
                Console.WriteLine($"Film with id {filmId} not found");
            }
            else
            {
                ConsoleTable.From(new[] { film.Copy<Film, FilmModel>() })
                            .Write();

                Console.WriteLine("Enter the Title");
                var title = Console.ReadLine().Trim();

                Console.WriteLine("Enter the Release Year");
                var releaseYear = Console.ReadLine().ToInt();

                Console.WriteLine("Enter the Rating");
                var rating = Console.ReadLine().Trim();

                if (!string.IsNullOrWhiteSpace(title) && film.Title != title)
                {
                    film.Title = title;
                }

                if (releaseYear > 0 && film.ReleaseYear != releaseYear)
                {
                    film.ReleaseYear = releaseYear;
                }

                if (!string.IsNullOrWhiteSpace(rating) && film.RatingCode != rating)
                {
                    film.RatingCode = rating;
                }

                MoviesContext.Instance.SaveChanges();

                var films = MoviesContext.Instance.Films
                                .Where(a => a.FilmId == filmId)
                                .Select(a => a.Copy<Film, FilmModel>());
                ConsoleTable.From(films).Write();
            }
        }

        internal static void DeleteItem()
        {
            Console.WriteLine("Delete an Actor");

            Console.WriteLine("Enter an Actor ID");
            var actorId = Console.ReadLine().ToInt();

            var actor = MoviesContext.Instance.Actors
                            .SingleOrDefault(a => a.ActorId == actorId);
            if (actor == null)
            {
                Console.WriteLine($"Actor with id {actorId} not found");
            }
            else
            {
                Console.WriteLine("Existing Actors");
                WriteActors();

                MoviesContext.Instance.Actors.Remove(actor);

                MoviesContext.Instance.SaveChanges();

                Console.WriteLine("With actor removed");
                WriteActors();
            }

            Console.WriteLine("Delete a Film");

            Console.WriteLine("Enter Film Title search");
            var title = Console.ReadLine();

            var film = MoviesContext.Instance.Films
                            .FirstOrDefault(f => f.Title.Contains(title));

            if (film == null)
            {
                Console.WriteLine($"Film with title that contains '{title}' not found");
            }
            else
            {
                ConsoleTable.From(new[] { film.Copy<Film, FilmModel>() }).Write();
                Console.WriteLine("Are you sure you want to delete this film?");
                if (Console.ReadKey().Key == ConsoleKey.Y)
                {
                    MoviesContext.Instance.Films.Remove(film);

                    MoviesContext.Instance.SaveChanges();

                    WriteFilms();
                }
                else
                {
                    Console.WriteLine(" No Films deleted");
                }
            }
        }

        private static void WriteActors()
        {
            var actors = MoviesContext.Instance.Actors
                            .Select(a => a.Copy<Actor, ActorModel>());
            ConsoleTable.From(actors).Write();
        }

        private static void WriteFilms()
        {
            var films = MoviesContext.Instance.Films
                            .Select(f => f.Copy<Film, FilmModel>());
            ConsoleTable.From(films).Write();
        }

        internal static void SelfAssessment()
        {
            Console.WriteLine("Existing Films");
            WriteFilms();
            #region batch insert
            for (int i = 0; i < 5; i++)
            {
                var film = new Film();
                film.Title = $"Test Film {i + 1}";
                film.RatingCode = "PG";
                film.Description = film.Title;
                MoviesContext.Instance.Films.Add(film);
            }
            MoviesContext.Instance.SaveChanges();
            Console.WriteLine("After Batch Insert");
            WriteFilms();
            #endregion

            #region batch update
            var filmsToUpdate = MoviesContext.Instance.Films
                .Where(f => 0 == f.FilmId % 2);
            foreach (Film film in filmsToUpdate)
            {
                film.Title = $"Awesome {film.Title}";
            }
            MoviesContext.Instance.SaveChanges();
            Console.WriteLine("After Batch Update");
            WriteFilms();
            #endregion

            #region batch delete
            var filmsToDelete = MoviesContext.Instance.Films
                .Where(f => f.Title.Contains("Test Film"));
            foreach (Film film in filmsToDelete)
            {
                MoviesContext.Instance.Films.Remove(film);
            }
            MoviesContext.Instance.SaveChanges();
            Console.WriteLine("After Batch Delete");
            WriteFilms();
            #endregion

            #region cleanup
            const string AWESOME = "Awesome ";
            var filmsToClean = MoviesContext.Instance.Films
                .Where(f => f.Title.StartsWith(AWESOME));
            foreach (Film film in filmsToClean)
            {
                film.Title = film.Title.Substring(AWESOME.Length);
            }
            MoviesContext.Instance.SaveChanges();
            Console.WriteLine("After Cleanup");
            WriteFilms();
            #endregion
        }
    }
}