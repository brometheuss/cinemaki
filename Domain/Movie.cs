using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Movie : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int LengthMinutes { get; set; }
        public string Plot { get; set; }
        public decimal BoxOffice { get; set; }
        public DateTime DebutDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Is3D { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public int RatedId { get; set; }
        public Rated Rated { get; set; }
        public ICollection<MovieGenre> MovieGenres { get; set; } = new List<MovieGenre>();
        public ICollection<MovieActor> MovieActors { get; set; }
        public ICollection<MovieLanguage> MovieLanguages { get; set; }
        public ICollection<MovieWriter> MovieWriters { get; set; }
        public int ProductionId { get; set; }
        public Production Production { get; set; }
        public ICollection<Poster> Posters { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Projection> Projections { get; set; }
    }
}
