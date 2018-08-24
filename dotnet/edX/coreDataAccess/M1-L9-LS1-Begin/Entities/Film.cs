using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieApp.Entities
{
    public partial class Film
    {
        public Film()
        {
            FilmActor = new HashSet<FilmActor>();
            FilmCategory = new HashSet<FilmCategory>();
        }

        public int FilmId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? ReleaseYear { get; set; }
        public int? RatingId { get; set; }

        [ForeignKey(nameof(RatingId))]
        public Rating Rating { get; set; }
        public string RatingCode { get; set; }
        public int? Runtime { get; set; }
        public int? FilmImageId { get; set; }

        [ForeignKey(nameof(FilmImageId))]
        public FilmImage FilmImage { get; set; }
        public ICollection<FilmActor> FilmActor { get; set; }
        public ICollection<FilmCategory> FilmCategory { get; set; }
    }
}
