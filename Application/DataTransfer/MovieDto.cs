using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DataTransfer
{
    public class MovieDto
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Movie title")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Movie description")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Movie length in minutes")]
        public int LengthMinutes { get; set; }
        [Required]
        [Display(Name = "Movie plot")]
        public string Plot { get; set; }
        [Required]
        [Display(Name = "Box office")]
        public decimal BoxOffice { get; set; }
        [Required]
        [Display(Name = "Theater release")]
        public DateTime DebutDate { get; set; }
        [Required]
        [Display(Name = "Last projection")]
        public DateTime EndDate { get; set; }
        [Required]
        [Display(Name = "3D")]
        public bool Is3D { get; set; }
        [Required]
        [Display(Name = "Country")]
        public int CountryId { get; set; }
        
        [Display(Name = "Country")]
        public string CountryName { get; set; }
        [Required]
        [Display(Name = "Production")]
        public int ProductionId { get; set; }
        
        [Display(Name = "Production")]
        public string ProductionName { get; set; }
        [Required]
        [Display(Name = "Rated")]
        public int RatedId { get; set; }
        
        [Display(Name = "Rated")]
        public string RatedName { get; set; }
        [Display(Name = "Genres")]
        public List<int> MovieGenres { get; set; }
        public IEnumerable<MovieGenreDto> GenresInfo { get; set; }
        [Display(Name = "Actors")]
        public List<int> MovieActors { get; set; }
        public IEnumerable<MovieActorDto> ActorsInfo { get; set; }
        [Display(Name = "Writers")]
        public List<int> MovieWriters { get; set; }
        public IEnumerable<MovieWriterDto> WritersInfo { get; set; }
        [Display(Name = "Languages")]
        public List<int> MovieLanguages { get; set; }
        public IEnumerable<MovieLanguageDto> LanguagesInfo { get; set; }
    }
}
