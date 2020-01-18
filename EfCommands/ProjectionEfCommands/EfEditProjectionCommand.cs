using Application.DataTransfer;
using Application.Exceptions;
using Application.ICommands.ProjectionCommands;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.ProjectionEfCommands
{
    public class EfEditProjectionCommand : EfBaseCommand, IEditProjectionCommand
    {
        public EfEditProjectionCommand(EfCinemakContext context) : base(context)
        {
        }

        public void Execute(ProjectionDto request)
        {
            var projection = Context.Projections.Find(request.Id);

            if (projection == null || projection.IsDeleted == true)
                throw new EntityNotFoundException("Projection");

            var query = Context.Projections.AsQueryable();
            query = query.Where(p => p.Id != request.Id);

            if (query.Any(p => p.DateBegin <= request.DateEnd && p.DateEnd >= request.DateEnd))
                throw new EntityAlreadyHasAnEntryException("projction at that time.");

            if (query.Any(p => p.DateEnd >= request.DateBegin && p.DateEnd <= request.DateEnd))
                throw new EntityAlreadyHasAnEntryException("projection at that time.");

            projection.DateBegin = request.DateBegin;
            projection.DateEnd = request.DateEnd;
            projection.HallId = request.HallId;
            projection.MovieId = request.MovieId;

            Context.SaveChanges();
        }
    }
}
