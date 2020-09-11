using Application.DataTransfer;
using Application.ICommands.CountryCommands;
using Application.Queries;
using Application.Responses;
using Domain;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.CountryEfCommands
{
    public class EfGetCountriesCommand : EfBaseCommand, IGetCountriesCommand
    {
        public EfGetCountriesCommand(EfCinemakContext context) : base(context)
        {
        }

        public int Id => 14;

        public string Name => "Get Countries using EntityFramework";

        public PagedResponse<CountryDto> Execute(CountryQuery request)
        {
            var query = Context.Countries.AsQueryable();

            query = query.Where(c => c.IsDeleted == false);

            if (request.Name != null)
                query = query.Where(c => c.Name.ToLower().Contains(request.Name.ToLower()));

            var totalCount = query.Count();

            query = query.Skip((request.PageNumber - 1) * request.PerPage).Take(request.PerPage);

            var pagesCount = (int)Math.Ceiling((double)totalCount / request.PerPage);

            return new PagedResponse<CountryDto>
            {
                CurrentPage = request.PageNumber,
                TotalCount = totalCount,
                PagesCount = pagesCount,
                Data = query.Select(c => new CountryDto
                {
                    Id = c.Id,
                    Name = c.Name
                })
            };
        }
    }
}
