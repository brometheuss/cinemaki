using Application.DataTransfer;
using Application.Exceptions;
using Application.ICommands.ProjectionCommands;
using Domain;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.ProjectionEfCommands
{
    public class EfAddProjectionCommand : EfBaseCommand, IAddProjectionCommand
    {
        public EfAddProjectionCommand(EfCinemakContext context) : base(context)
        {
        }

        public int Id => 46;

        public string Name => "Create Projection using EntityFramework";

        public void Execute(ProjectionDto request)
        {
            var query = Context.Projections.AsQueryable();

            query = query.Where(c => c.IsDeleted == false);
            query = query.Where(c => c.HallId == request.HallId);

            if (query.Any(p => p.DateBegin <= request.DateEnd && p.DateEnd >= request.DateEnd))
                throw new EntityAlreadyHasAnEntryException("projection at that time.");

            if (query.Any(p => p.DateEnd >= request.DateBegin && p.DateEnd <= request.DateEnd))
                throw new EntityAlreadyHasAnEntryException("projection at that time.");

            Context.Projections.Add(new Projection
            {
                DateBegin = request.DateBegin,
                DateEnd = request.DateEnd,
                HallId = request.HallId,
                MovieId = request.MovieId
            }); 

            Context.SaveChanges();
        }
    }
}
