using Application.DataTransfer;
using Application.ICommands.LogCommands;
using Application.Queries;
using Application.Responses;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.LogEfCommands
{
    public class EfGetLogsCommand : EfBaseCommand, IGetLogsCommand
    {
        public EfGetLogsCommand(EfCinemakContext context) : base(context)
        {
        }

        public int Id => 83;

        public string Name => "Get Logs using EntityFramework";

        public PagedResponse<LogDto> Execute(LogQuery request)
        {
            var query = Context.Logs.AsQueryable();

            if (request.UserId > 0)
                query = query.Where(l => l.UserId == request.UserId);

            if (request.Action != null)
                query = query.Where(l => l.Action.ToLower().Contains(request.Action.ToLower()));

            if (request.Success != null)
                query = query.Where(l => l.Success == request.Success);

            if (request.DateAfter != null)
                query = query.Where(l => l.Date >= request.DateAfter);

            if (request.DateBefore != null)
                query = query.Where(l => l.Date <= request.DateBefore);

            var totalCount = query.Count();

            query = query.Skip((request.PageNumber - 1) * request.PerPage).Take(request.PerPage);

            var pagesCount = (int)Math.Ceiling((double)totalCount / request.PerPage);

            return new PagedResponse<LogDto>
            {
                CurrentPage = request.PageNumber,
                PagesCount = pagesCount,
                TotalCount = totalCount,
                Data = query.Select(l => new LogDto
                {
                    Id = l.Id,
                    UserId = l.UserId,
                    Action = l.Action,
                    Date = l.Date
                })
            };
        }
    }
}
