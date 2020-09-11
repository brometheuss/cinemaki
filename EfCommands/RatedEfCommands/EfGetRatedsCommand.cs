using Application.DataTransfer;
using Application.ICommands.RatedCommands;
using Application.Queries;
using Application.Responses;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.RatedEfCommands
{
    public class EfGetRatedsCommand : EfBaseCommand, IGetRatedsCommand
    {
        public EfGetRatedsCommand(EfCinemakContext context) : base(context)
        {
        }

        public int Id => 55;

        public string Name => "Get Rateds using EntityFramework";

        public PagedResponse<RatedDto> Execute(RatedQuery request)
        {
            var query = Context.Rateds.AsQueryable();

            query = query.Where(r => r.IsDeleted == false);

            if (request.Name != null)
                query = query.Where(r => r.Name.ToLower().Contains(request.Name.ToLower()));

            var totalCount = query.Count();

            query = query.Skip((request.PageNumber - 1) * request.PerPage).Take(request.PerPage);

            var pagesCount = (int)Math.Ceiling((double)totalCount / request.PerPage);

            return new PagedResponse<RatedDto>
            {
                CurrentPage = request.PageNumber,
                PagesCount = pagesCount,
                TotalCount = totalCount,
                Data = query.Select(r => new RatedDto
                {
                    Id = r.Id,
                    Name = r.Name
                })
            };
        }
    }
}
