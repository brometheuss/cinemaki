using Application.DataTransfer;
using Application.Exceptions;
using Application.ICommands.MovieCommands;
using EfDataAccess;
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

        public void Execute(MovieDto request)
        {
            var movie = Context.Movies.Find(request.Id);

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



            Context.SaveChanges();
        }
    }
}
