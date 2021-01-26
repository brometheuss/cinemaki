using Application.DataTransfer;
using Application.ICommands.ProjectionCommands;
using Application.Queries;
using Application.Responses;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.ProjectionEfCommands
{
    public class EfGetProjectionsCommand : EfBaseCommand, IGetProjectionsCommand
    {
        public EfGetProjectionsCommand(EfCinemakContext context) : base(context)
        {
        }

        public int Id => 50;

        public string Name => "Get Projections using EntityFramework";

        public PagedResponse<ProjectionDto> Execute(ProjectionQuery request)
        {
            var query = Context.Projections
                .Include(m => m.Movie)
                .Include(h => h.Hall)
                .OrderByDescending(x => x.DateBegin)
                .AsQueryable();

            query = query.Where(p => p.IsDeleted == false);

            if (request.BeginsAfter != null)
                query = query.Where(p => p.DateBegin > request.BeginsAfter);

            if (request.EndsBefore != null)
                query = query.Where(p => p.DateEnd < request.EndsBefore);

            if (request.MovieId > 0)
                query = query.Where(p => p.MovieId == request.MovieId);

            var totalCount = query.Count();

            query = query.Skip((request.PageNumber - 1) * request.PerPage).Take(request.PerPage);

            var pagesCount = (int)Math.Ceiling((double)totalCount / request.PerPage);

            return new PagedResponse<ProjectionDto>
            {
                CurrentPage = request.PageNumber,
                PagesCount = pagesCount,
                TotalCount = totalCount,
                Data = query.Select(p => new ProjectionDto
                {
                    Id = p.Id,
                    DateBegin = p.DateBegin,
                    DateEnd = p.DateEnd,
                    HallId = p.Hall.Id,
                    HallName = p.Hall.Name,
                    MovieId = p.Movie.Id,
                    MovieName = p.Movie.Title
                })
            };
        }
    }
}
