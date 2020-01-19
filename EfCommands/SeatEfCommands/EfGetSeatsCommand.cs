using Application.DataTransfer;
using Application.ICommands.SeatCommands;
using Application.Queries;
using Application.Responses;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.SeatEfCommands
{
    public class EfGetSeatsCommand : EfBaseCommand, IGetSeatsCommand
    {
        public EfGetSeatsCommand(EfCinemakContext context) : base(context)
        {
        }

        public PagedResponse<SeatDto> Execute(SeatQuery request)
        {
            var query = Context.Seats.AsQueryable();

            query = query.Where(s => s.IsDeleted == false);

            if (request.Name != null)
                query = query.Where(s => s.Name.ToLower().Contains(request.Name.ToLower()));

            if (request.HallId > 0)
                query = query.Where(s => s.HallId == request.HallId);

            if (request.Number > 0)
                query = query.Where(s => s.Number == request.Number);

            var totalCount = query.Count();

            query = query.Skip((request.PageNumber - 1) * request.PerPage).Take(request.PerPage);

            var pagesCount = (int)Math.Ceiling((double)totalCount / request.PerPage);

            return new PagedResponse<SeatDto>
            {
                CurrentPage = request.PageNumber,
                PagesCount = pagesCount,
                TotalCount = totalCount,
                Data = query.Select(s => new SeatDto
                {
                    Id = s.Id,
                    HallId = s.HallId,
                    IsBroken = s.IsBroken,
                    Name = s.Name,
                    Number  = s.Number
                })
            };
        }
    }
}
