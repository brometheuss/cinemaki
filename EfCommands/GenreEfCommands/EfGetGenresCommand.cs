using Application.DataTransfer;
using Application.ICommands.GenreCommands;
using Application.Queries;
using Application.Responses;
using Domain;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.GenreEfCommands
{
    public class EfGetGenresCommand : EfBaseCommand, IGetGenresCommand
    {
        public EfGetGenresCommand(EfCinemakContext context) : base(context)
        {
        }

        public PagedResponse<GenreDto> Execute(GenreQuery request)
        {
            var query = Context.Genres.AsQueryable();

            query = query.Where(g => g.IsDeleted == false);

            if (request.Name != null)
                query = query.Where(g => g.Name.ToLower().Contains(request.Name.ToLower()));

            var totalCount = query.Count();

            query = query.Skip((request.PageNumber - 1) * request.PerPage).Take(request.PerPage);

            var pagesCount = (int)Math.Ceiling((double)totalCount / request.PerPage);

            return new PagedResponse<GenreDto>
            {
                CurrentPage = request.PageNumber,
                PagesCount = pagesCount,
                TotalCount = totalCount,
                Data = query.Select(g => new GenreDto
                {
                    Id = g.Id,
                    Name = g.Name
                })
            };
        }
    }
}
