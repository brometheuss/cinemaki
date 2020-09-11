using Application.DataTransfer;
using Application.Exceptions;
using Application.ICommands.MovieCommands;
using Domain;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.MovieEfCommands
{
    public class EfEditMovieCommand : EfBaseCommand, IEditMovieCommand
    {
        public EfEditMovieCommand(EfCinemakContext context) : base(context)
        {
        }

        public int Id => 33;

        public string Name => "Edit Movie using EntityFramework";

        public void Execute(MovieDto request)
        {
            var movie = Context.Movies.Where(m => m.Id == request.Id).Include(m => m.MovieGenres).FirstOrDefault();

            if (movie == null || movie.IsDeleted == true)
                throw new EntityNotFoundException("Movie");

            //if (request.Title.ToLower() != movie.Title.ToLower() && Context.Movies.Any(m => m.Title.ToLower() == request.Title.ToLower()))
            //    throw new EntityAlreadyExistsException("Movie Title");

            movie.Title = request.Title;
            movie.Description = request.Description;
            movie.Plot = request.Plot;
            movie.BoxOffice = request.BoxOffice;
            movie.DebutDate = request.DebutDate;
            movie.EndDate = request.EndDate;
            movie.Is3D = request.Is3D;
            movie.LengthMinutes = request.LengthMinutes;
            movie.ProductionId = request.ProductionId;
            movie.RatedId = request.RatedId;
            movie.CountryId = request.CountryId;

            var genres = movie.MovieGenres;

            Context.Set<MovieGenre>().RemoveRange(genres);

            foreach(var gid in request.MovieGenres)
            {
                movie.MovieGenres.Add(new MovieGenre
                {
                    Movie = movie,
                    GenreId = gid
                });
            }

            var actors = movie.MovieActors;

            Context.Set<MovieActor>().RemoveRange(actors);

            foreach(var aid in request.MovieActors)
            {
                movie.MovieActors.Add(new MovieActor
                {
                    Movie = movie,
                    ActorId = aid
                });
            }

            var writers = movie.MovieWriters;

            Context.Set<MovieWriter>().RemoveRange(writers);

            foreach(var wid in request.MovieWriters)
            {
                movie.MovieWriters.Add(new MovieWriter
                {
                    Movie = movie,
                    WriterId = wid
                });
            }

            var langs = movie.MovieLanguages;

            Context.Set<MovieLanguage>().RemoveRange(langs);

            foreach(var lid in request.MovieLanguages)
            {
                movie.MovieLanguages.Add(new MovieLanguage
                {
                    Movie = movie,
                    LanguageId = lid
                });
            }

            Context.SaveChanges();
        }
    }
}
