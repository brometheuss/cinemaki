using Application.DataTransfer;
using Application.Exceptions;
using Application.ICommands.GenreCommands;
using Domain;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.GenreEfCommands
{
    public class EfAddGenreCommand : EfBaseCommand, IAddGenreCommand
    {
        public EfAddGenreCommand(EfCinemakContext context) : base(context)
        {
        }

        public int Id => 16;

        public string Name => "Create Genre using EntityFramework";

        public void Execute(GenreDto request)
        {
            if (Context.Genres.Any(g => g.Name.ToLower() == request.Name.ToLower()))
                throw new EntityAlreadyExistsException("Genre");

            Context.Genres.Add(new Genre
            {
                Name = request.Name
            });

            Context.SaveChanges();
        }
    }
}
