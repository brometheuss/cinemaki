using Application.Exceptions;
using Application.ICommands.RatedCommands;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands.RatedEfCommands
{
    public class EfDeleteRatedCommand : EfBaseCommand, IDeleteRatedCommand
    {
        public EfDeleteRatedCommand(EfCinemakContext context) : base(context)
        {
        }

        public int Id => 52;

        public string Name => "Delete Rated using EntityFramework";

        public void Execute(int request)
        {
            var rated = Context.Rateds.Find(request);

            if (rated == null || rated.IsDeleted == true)
                throw new EntityNotFoundException("Rating");

            rated.IsDeleted = true;

            Context.SaveChanges();
        }
    }
}
