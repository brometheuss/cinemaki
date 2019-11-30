using Application.DataTransfer;
using Application.ICommands.RoleCommands;
using Application.Queries;
using Application.Responses;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.RoleEfCommands
{
    public class EfGetRolesCommand : EfBaseCommand, IGetRolesCommand
    {
        public EfGetRolesCommand(EfCinemakContext context) : base(context)
        {
        }

        public PagedResponse<RoleDto> Execute(RoleQuery request)
        {
            var query = Context.Roles.AsQueryable();

            query = query.Where(r => r.IsDeleted == false);

            if (request.Name != null)
                query = query.Where(r => r.Name.ToLower().Contains(request.Name.ToLower()));

            var totalCount = query.Count();

            query = query.Skip((request.PageNumber - 1) * request.PerPage).Take(request.PerPage);

            var pagesCount = (int)Math.Ceiling((double)totalCount / request.PerPage);

            return new PagedResponse<RoleDto>
            {
                CurrentPage = request.PageNumber,
                PagesCount = pagesCount,
                TotalCount = totalCount,
                Data = query.Select(r => new RoleDto
                {
                    Id = r.Id,
                    Name = r.Name
                })
            };
        }
    }
}
