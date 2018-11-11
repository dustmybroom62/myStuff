using System;
using System.Collections.Generic;

namespace MyApp.Models
{
    public partial class FilmActor
    {
        public short ActorId { get; set; }
        public short FilmId { get; set; }
        public DateTimeOffset LastUpdate { get; set; }

        public Actor Actor { get; set; }
        public Film Film { get; set; }
    }
}
