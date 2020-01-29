using Application.DataTransfer;
using Application.ICommands.HallCommands;
using Application.Queries;
using Application.Responses;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.HallEfCommands
{
    public class EfGetHallsCommand : EfBaseCommand, IGetHallsCommand
    {
        public EfGetHallsCommand(EfCinemakContext context) : base(context)
        {
        }

        public PagedResponse<HallDto> Execute(HallQuery request)
        {
            var query = Context.Halls
                .AsQueryable();

            query = query.Where(h => h.IsDeleted == false);

            if (request.Name != null)
                query = query.Where(h => h.Name.ToLower().Contains(request.Name.ToLower()));

            if (request.MaximumOccupancy > 0)
                query = query.Where(h => h.MaximumOccupancy < request.MaximumOccupancy);

            if (request.MinimumOccupancy > 0)
                query = query.Where(h => h.MaximumOccupancy > request.MinimumOccupancy);

            var totalCount = query.Count();

            query = query.Skip((request.PageNumber - 1) * request.PerPage).Take(request.PerPage);

            var pagesCount = (int)Math.Ceiling((double)totalCount / request.PerPage);

            return new PagedResponse<HallDto>
            {
                TotalCount = totalCount,
                PagesCount = pagesCount,
                CurrentPage = request.PageNumber,
                Data = query.Select(h => new HallDto
                {
                    Id = h.Id,
                    Name = h.Name,
                    MaximumOccupancy = h.MaximumOccupancy
                })
            };
        }
    }
}
