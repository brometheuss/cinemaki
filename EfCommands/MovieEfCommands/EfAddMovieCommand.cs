using Application.DataTransfer;
using Application.Exceptions;
using Application.ICommands.MovieCommands;
using Domain;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.MovieEfCommands
{
    public class EfAddMovieCommand : EfBaseCommand, IAddMovieCommand
    {
        public EfAddMovieCommand(EfCinemakContext context) : base(context)
        {
        }

        public void Execute(MovieDto request)
        {
            var movie = new Movie
            {
                Title = request.Title,
                Plot = request.Plot,
                Description = request.Description,
                CountryId = request.CountryId,
                ProductionId = request.ProductionId,
                RatedId = request.RatedId,
                DebutDate = request.DebutDate,
                EndDate = request.EndDate,
                LengthMinutes = request.LengthMinutes,
                BoxOffice = request.BoxOffice,
                Is3D = request.Is3D,
            };

            var existingGenreIds = Context.Genres.Select(z => z.Id);

            if (existingGenreIds.Intersect(request.MovieGenresList).Count() != request.MovieGenresList.Count)
            {
                throw new EntityNotFoundException("Not all genre ids are in database.");
            }

            Context.Movies.Add(movie);

            request.MovieGenresList.ForEach(id =>
            {
                movie.MovieGenres.Add(new MovieGenre
                {
                    GenreId = id
                });
            });

            Context.SaveChanges();
        }
    }
}
