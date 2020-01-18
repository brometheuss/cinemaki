using Application.DataTransfer;
using Application.Exceptions;
using Application.ICommands.ProjectionCommands;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands.ProjectionEfCommands
{
    public class EfGetProjectionCommand : EfBaseCommand, IGetProjectionCommand
    {
        public EfGetProjectionCommand(EfCinemakContext context) : base(context)
        {
        }

        public ProjectionDto Execute(int request)
        {
            var projection = Context.Projections.Find(request);

            if (projection == null || projection.IsDeleted == true)
                throw new EntityNotFoundException("Projection");

            return new ProjectionDto
            {
                Id = projection.Id,
                DateBegin = projection.DateBegin,
                DateEnd = projection.DateEnd,
                HallId = projection.HallId,
                MovieId = projection.MovieId
            };
        }
    }
}
