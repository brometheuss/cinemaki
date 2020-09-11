using Application.DataTransfer;
using Application.ICommands.ActorCommands;
using Application.Queries;
using Application.Responses;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.ActorEfCommands
{
    public class EfGetActorsCommand : EfBaseCommand, IGetActorsCommand
    {
        public EfGetActorsCommand(EfCinemakContext context) : base(context)
        {
        }

        public int Id => 5;

        public string Name => "Get Actors using EntityFramework";

        public PagedResponse<ActorDto> Execute(ActorQuery request)
        {
            var query = Context.Actors.AsQueryable();

            query = query.Where(a => a.IsDeleted == false);

            if (request.FirstName != null)
                query = query.Where(a => a.FirstName.ToLower().Contains(request.FirstName.ToLower()));

            if (request.LastName != null)
                query = query.Where(a => a.LastName.ToLower().Contains(request.LastName.ToLower()));

            var totalCount = query.Count();

            query = query.Skip((request.PageNumber - 1) * request.PerPage).Take(request.PerPage);

            var pagesCount = (int)Math.Ceiling((double)totalCount / request.PerPage);

            return new PagedResponse<ActorDto>
            {
                CurrentPage = request.PageNumber,
                PagesCount = pagesCount,
                TotalCount = totalCount,
                Data = query.Select(a => new ActorDto
                {
                    Id = a.Id,
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    Link = a.Link
                })
            };
        }
    }
}
