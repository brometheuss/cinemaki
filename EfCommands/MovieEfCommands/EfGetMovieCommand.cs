using Application.DataTransfer;
using Application.Exceptions;
using Application.ICommands.MovieCommands;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.MovieEfCommands
{
    public class EfGetMovieCommand : EfBaseCommand, IGetMovieCommand
    {
        public EfGetMovieCommand(EfCinemakContext context) : base(context)
        {
        }

        public MovieDto Execute(int request)
        {
            var movie = Context.Movies.Find(request);

            var query = Context.Movies
                .Include(mg => mg.MovieGenres)
                .ThenInclude(g => g.Genre);

            if (movie == null || movie.IsDeleted == true)
                throw new EntityNotFoundException("Movie");

            return new MovieDto
            {
                Id = movie.Id,
                Title = movie.Title,
                Plot = movie.Plot,
                Description = movie.Description,
                CountryId = movie.CountryId,
                ProductionId = movie.ProductionId,
                RatedId = movie.RatedId,
                DebutDate = movie.DebutDate,
                EndDate = movie.EndDate,
                LengthMinutes = movie.LengthMinutes,
                BoxOffice = movie.BoxOffice,
                Is3D = movie.Is3D,
                GenresInfo = movie.MovieGenres.Select(g => new MovieGenreDto
                {
                    GenreId = g.GenreId,
                    GenreName = g.Genre.Name
                })
            };
        }
    }
}
