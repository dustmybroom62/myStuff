using System;
using System.Linq;
using MovieApp.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace MovieApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new MoviesContext();
            // Console.WriteLine(context.Film.Count().ToString());
            List<int> actorId = new List<int>(new int[] {1, 4, 12, 13});
            // var q = from f in context.Film
            //     join fa in ( from x in context.FilmActor
            //     where x.ActorId == actorId select x )
            //     on f.FilmId equals fa.FilmId
            // group f by f.Title into newgroup
            // orderby newgroup.Key
            // select newgroup;
            // select new {
            //     FilmId = f.FilmId,
            //     Title = f.Title,
            //     FilmActor = gj
            // };
            // from ng2 in (
            //     from od in ng1
            // )
            // where fa.ActorId == actorId
            // group f by f.FilmId; // into newgroup
            //select newgroup;
            // orderby newgroup.Key
            //select new { f, fa };

            // foreach(var f in q) {
            //     context.Entry(f).Collection(e => e.FilmActor)
            //     .Query().Where(e => e.ActorId == actorId).Load();
            // }

            var q = from fa in context.FilmActor
                    where actorId.Contains( fa.ActorId )
                    join f in context.Film
                    on fa.FilmId equals f.FilmId
                    // orderby f.FilmId
                    select new
                    {
                        f,
                        fa
                    };

            HashSet<Film> films = new HashSet<Film>();
            int counter = 0;
            foreach (var film in q)
            {
                counter++;
                Film exist = films.FirstOrDefault(e => e.FilmId == film.f.FilmId);
                if (null == exist)
                {
                    // Console.WriteLine(film.f.Title);
                    films.Add(exist = film.f);
                    // films.Last().FilmActor = new List<FilmActor>();
                }
                // Console.WriteLine($"\t {film.fa.ActorId}");
                exist.FilmActor.Add(film.fa);
            }
            Console.WriteLine($"-------------------- {counter} records ----------------------");
            foreach(var film in films) {
                Console.WriteLine(film.Title);
                foreach(var fa in film.FilmActor) {
                Console.WriteLine($"\t {fa.ActorId}");
                }
            }
        }
    }
}
