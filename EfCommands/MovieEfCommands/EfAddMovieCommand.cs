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

            if (!request.MovieGenres.All(id => existingGenreIds.Any(e => e == id)))
            {
                throw new EntityNotFoundException("One or more genres not found.");
            }

            Context.Movies.Add(movie);

            request.MovieGenres.ForEach(id =>
            {
                movie.MovieGenres.Add(new MovieGenre
                {
                    GenreId = id
                });
            });

            var existingActorIds = Context.Actors.Select(a => a.Id);

            if(!request.MovieActors.All(id => existingActorIds.Any(e => e == id)))
            {
                throw new EntityNotFoundException("One or more actors not found.");
            }

            request.MovieActors.ForEach(id =>
            {
                movie.MovieActors.Add(new MovieActor
                {
                    ActorId = id
                });
            });

            Context.SaveChanges();
        }
    }
}
