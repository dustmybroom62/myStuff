using System;
using System.Collections.Generic;

namespace MovieAPI.Entities
{
    public partial class Actor
    {
        public Actor()
        {
            FilmActor = new HashSet<FilmActor>();
        }

        public int ActorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<FilmActor> FilmActor { get; set; }
    }
}
