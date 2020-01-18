using Application.Exceptions;
using Application.ICommands.PosterCommands;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands.PosterEfCommands
{
    public class EfDeletePosterCommand : EfBaseCommand, IDeletePosterCommand
    {
        public EfDeletePosterCommand(EfCinemakContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var poster = Context.Posters.Find(request);

            if (poster == null || poster.IsDeleted == true)
                throw new EntityNotFoundException("Poster");

            poster.IsDeleted = true;

            Context.SaveChanges();
        }
    }
}
