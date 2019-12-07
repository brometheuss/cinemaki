using Application.DataTransfer;
using Application.Exceptions;
using Application.ICommands.GenreCommands;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands.GenreEfCommands
{
    public class EfGetGenreCommand : EfBaseCommand, IGetGenreCommand
    {
        public EfGetGenreCommand(EfCinemakContext context) : base(context)
        {
        }

        public GenreDto Execute(int request)
        {
            var genre = Context.Genres.Find(request);

            if (genre == null || genre.IsDeleted == true)
                throw new EntityNotFoundException("Genre");

            return new GenreDto
            {
                Id = genre.Id,
                Name = genre.Name
            };
        }
    }
}
