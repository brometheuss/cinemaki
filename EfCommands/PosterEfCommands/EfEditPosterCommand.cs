using Application.DataTransfer;
using Application.Exceptions;
using Application.ICommands.PosterCommands;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands.PosterEfCommands
{
    public class EfEditPosterCommand : EfBaseCommand, IEditPosterCommand
    {
        public EfEditPosterCommand(EfCinemakContext context) : base(context)
        {
        }

        public int Id => 38;

        public string Name => "Edit Poster using EntityFramework";

        public void Execute(PosterDto request)
        {
            var poster = Context.Posters.Find(request.Id);

            if (poster == null || poster.IsDeleted == true)
                throw new EntityNotFoundException("Poster");

            if (poster.Name.ToLower() == request.Name.ToLower())
                throw new EntityAlreadyExistsException("Poster name");

            poster.PosterTitle = request.PosterTitle;
            poster.Alt = request.Alt;
            poster.Name = request.Name;
            poster.MovieId = request.MovieId;

            Context.SaveChanges();
        }
    }
}
