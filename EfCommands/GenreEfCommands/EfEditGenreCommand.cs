using Application.DataTransfer;
using Application.Exceptions;
using Application.ICommands.GenreCommands;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.GenreEfCommands
{
    public class EfEditGenreCommand : EfBaseCommand, IEditGenreCommand
    {
        public EfEditGenreCommand(EfCinemakContext context) : base(context)
        {
        }

        public void Execute(GenreDto request)
        {
            var genre = Context.Genres.Find(request.Id);

            if (genre == null || genre.IsDeleted == true)
                throw new EntityNotFoundException("Genre");

            if (request.Name.ToLower() != genre.Name.ToLower() && Context.Genres.Any(r => r.Name.ToLower() == request.Name.ToLower()))
                throw new EntityAlreadyExistsException("Genre");

            genre.Name = request.Name;

            Context.SaveChanges();
        }
    }
}
