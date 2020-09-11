using Application.Exceptions;
using Application.ICommands.GenreCommands;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands.GenreEfCommands
{
    public class EfDeleteGenreCommand : EfBaseCommand, IDeleteGenreCommand
    {
        public EfDeleteGenreCommand(EfCinemakContext context) : base(context)
        {
        }

        public int Id => 17;

        public string Name => "Delete Genre using EntityFramework";

        public void Execute(int request)
        {
            var genre = Context.Genres.Find(request);

            if (genre == null || genre.IsDeleted == true)
                throw new EntityNotFoundException("Genre");

            genre.IsDeleted = true;

            Context.SaveChanges();
        }
    }
}
