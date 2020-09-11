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
    public class EfDeleteMovieCommand : EfBaseCommand, IDeleteMovieCommand
    {
        public EfDeleteMovieCommand(EfCinemakContext context) : base(context)
        {
        }

        public int Id => 32;

        public string Name => "Delete Movie using EntityFramework";

        public void Execute(int request)
        {
            var movie = Context.Movies.Find(request);

            if (movie == null || movie.IsDeleted == true)
                throw new EntityNotFoundException("Movie");

            Context.Movies.Remove(movie);

            Context.SaveChanges();
        }
    }
}
