using Application.DataTransfer;
using Application.ICommands.ProductionCommands;
using Application.Queries;
using Application.Responses;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.ProductionEfCommands
{
    public class EfGetProductionsCommand : EfBaseCommand, IGetProductionsCommand
    {
        public EfGetProductionsCommand(EfCinemakContext context) : base(context)
        {
        }

        public PagedResponse<ProductionDto> Execute(ProductionQuery request)
        {
            var query = Context.Production.AsQueryable();

            query = query.Where(p => p.IsDeleted == false);

            if (request.Name != null)
                query = query.Where(p => p.Name.ToLower().Contains(request.Name.ToLower()));

            var totalCount = query.Count();

            query = query.Skip((request.PageNumber - 1) * request.PerPage).Take(request.PerPage);

            var pagesCount = (int)Math.Ceiling((double)totalCount / request.PerPage);

            return new PagedResponse<ProductionDto>
            {
                CurrentPage = request.PageNumber,
                PagesCount = pagesCount,
                TotalCount = totalCount,
                Data = query.Select(p => new ProductionDto
                {
                    Id = p.Id,
                    Name = p.Name
                })
            };
        }
    }
}
