using Application.DataTransfer;
using Application.Exceptions;
using Application.ICommands.PosterCommands;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands.PosterEfCommands
{
    public class EfGetPosterCommand : EfBaseCommand, IGetPosterCommand
    {
        public EfGetPosterCommand(EfCinemakContext context) : base(context)
        {
        }

        public PosterDto Execute(int request)
        {
            var poster = Context.Posters.Find(request);

            if (poster == null || poster.IsDeleted == true)
                throw new EntityNotFoundException("Poster");

            return new PosterDto
            {
                Id = poster.Id,
                PosterTitle = poster.PosterTitle,
                Alt = poster.Alt,
                Name = poster.Name,
                MovieId = poster.MovieId,
                //MovieName = poster.Movie.Title
            };
        }
    }
}
