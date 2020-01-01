﻿using System;
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
        public List<int> MovieGenres { get; set; }
        public IEnumerable<MovieGenreDto> GenresInfo { get; set; }
        public List<int> MovieActors { get; set; }
        public IEnumerable<MovieActorDto> ActorsInfo { get; set; }
        public List<int> MovieWriters { get; set; }
        public IEnumerable<MovieWriterDto> WritersInfo { get; set; }
        public List<int> MovieLanguages { get; set; }
        public IEnumerable<MovieLanguageDto> LanguagesInfo { get; set; }
    }
}