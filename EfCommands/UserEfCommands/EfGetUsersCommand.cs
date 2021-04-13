using Application.DataTransfer;
using Application.ICommands.UserCommands;
using Application.Queries;
using Application.Responses;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.UserEfCommands
{
    public class EfGetUsersCommand : EfBaseCommand, IGetUsersCommand
    {
        public EfGetUsersCommand(EfCinemakContext context) : base(context)
        {
        }

        public int Id => 75;

        public string Name => "Get Users using EntityFramework";

        public PagedResponse<ShowUserDto> Execute(UserQuery request)
        {
            var query = Context.Users
                .Include(r => r.Role)
                .AsQueryable();

            if(request.ISDeleted != null)
            {
                if (request.ISDeleted == 1)
                {
                    query = query.Where(u => u.IsDeleted == true);
                }
                else
                {
                    query = query.Where(u => u.IsDeleted == false);
                }
            }

            if (request.FirstName != null)
                query = query.Where(u => u.FirstName.ToLower().Contains(request.FirstName.ToLower()));

            if (request.LastName != null)
                query = query.Where(u => u.LastName.ToLower().Contains(request.LastName.ToLower()));

            if (request.Username != null)
                query = query.Where(u => u.Username.ToLower().Contains(request.Username.ToLower()));

            if (request.Email != null)
                query = query.Where(u => u.Email.ToLower().Contains(request.Email.ToLower()));

            if (request.RoleName != null)
                query = query.Where(u => u.Role.Name.ToLower().Contains(request.RoleName.ToLower()));

            var totalCount = query.Count();

            query = query.Skip((request.PageNumber - 1) * request.PerPage).Take(request.PerPage);

            var pagesCount = (int)Math.Ceiling((double)totalCount / request.PerPage);

            return new PagedResponse<ShowUserDto>
            {
                CurrentPage = request.PageNumber,
                PagesCount = pagesCount,
                TotalCount = totalCount,
                Data = query.Select(u => new ShowUserDto
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    Username = u.Username,
                    RoleName = u.Role.Name
                })
            };
        }
    }
}
