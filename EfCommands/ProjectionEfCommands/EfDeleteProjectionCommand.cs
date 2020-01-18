using Application.Exceptions;
using Application.ICommands.ProjectionCommands;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands.ProjectionEfCommands
{
    public class EfDeleteProjectionCommand : EfBaseCommand, IDeleteProjectionCommand
    {
        public EfDeleteProjectionCommand(EfCinemakContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var projection = Context.Projections.Find(request);

            if (projection == null || projection.IsDeleted == true)
                throw new EntityNotFoundException("Projection");

            projection.IsDeleted = true;

            Context.SaveChanges();
        }
    }
}
