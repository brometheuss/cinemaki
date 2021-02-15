using Application.DataTransfer;
using Application.Exceptions;
using Application.ICommands.ProjectionCommands;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.ProjectionEfCommands
{
    public class EfGetProjectionCommand : EfBaseCommand, IGetProjectionCommand
    {
        public EfGetProjectionCommand(EfCinemakContext context) : base(context)
        {
        }

        public int Id => 49;

        public string Name => "Get Projection using EntityFramework";

        public ProjectionDto Execute(int request)
        {
            var projection = Context.Projections
                .Where(p => p.Id == request)
                .Include(h => h.Hall)
                .ThenInclude(s => s.Seats)
                .Include(m => m.Movie)
                .FirstOrDefault();

            if (projection == null || projection.IsDeleted == true)
                throw new EntityNotFoundException("Projection");

            return new ProjectionDto
            {
                Id = projection.Id,
                DateBegin = projection.DateBegin,
                DateEnd = projection.DateEnd,
                HallId = projection.HallId,
                HallName = projection.Hall.Name,
                MovieId = projection.MovieId,
                MovieName = projection.Movie.Title,
                HallOccupancy = projection.Hall.MaximumOccupancy
            };
        }
    }
}
