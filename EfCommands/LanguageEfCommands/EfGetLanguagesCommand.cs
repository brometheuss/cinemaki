using Application.DataTransfer;
using Application.ICommands.LanguageCommands;
using Application.Queries;
using Application.Responses;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.LanguageEfCommands
{
    public class EfGetLanguagesCommand : EfBaseCommand, IGetLanguagesCommand
    {
        public EfGetLanguagesCommand(EfCinemakContext context) : base(context)
        {
        }

        public int Id => 30;

        public string Name => "Get Languages using EntityFramework";

        public PagedResponse<LanguageDto> Execute(LanguageQuery request)
        {
            var query = Context.Languages.AsQueryable();

            query = query.Where(l => l.IsDeleted == false);

            if (request.Name != null)
                query = query.Where(l => l.Name.ToLower().Contains(request.Name.ToLower()));

            var totalCount = query.Count();

            query = query.Skip((request.PageNumber - 1) * request.PerPage).Take(request.PerPage);

            var pagesCount = (int)Math.Ceiling((double)totalCount / request.PerPage);

            return new PagedResponse<LanguageDto>
            {
                CurrentPage = request.PageNumber,
                PagesCount = pagesCount,
                TotalCount = totalCount,
                Data = query.Select(l => new LanguageDto 
                {
                    Id = l.Id,
                    Name = l.Name
                })
            };
        }
    }
}
