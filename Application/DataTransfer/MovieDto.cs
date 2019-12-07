using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransfer
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int LengthMinutes { get; set; }
        public string Plot { get; set; }
        public decimal BoxOffice { get; set; }
        public DateTime DebutDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Is3D { get; set; }
        public int CountryId { get; set; }
        public int ProductionId { get; set; }
        public int RatedId { get; set; }
        public string CountryName { get; set; }
        public List<int> MovieGenresList { get; set; }
        public IEnumerable<MovieGenreDto> GenresInfo { get; set; }
    }
}
