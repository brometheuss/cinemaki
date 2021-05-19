using Application.DataTransfer;
using Application.Exceptions;
using Application.ICommands.MovieCommands;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands.MovieEfCommands
{
    public class EfActivateMovieCommand : EfBaseCommand, IActivateMovieCommand
    {
        public EfActivateMovieCommand(EfCinemakContext context) : base(context)
        {
        }

        public int Id => throw new NotImplementedException();

        public string Name => "Activate/Deactivate movie using Entity Framework.";

        public void Execute(MovieDto request)
        {
            var movie = Context.Movies.Find(request.Id);

            if (movie == null)
                throw new EntityNotFoundException("Movie");

            if(request.IsActive == true)
            {
                movie.IsActive = false;
            }
            else
            {
                movie.IsActive = true;
            }

            Context.SaveChanges();
        }
    }
}
