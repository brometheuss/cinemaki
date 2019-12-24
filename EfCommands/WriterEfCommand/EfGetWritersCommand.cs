using Application.DataTransfer;
using Application.ICommands.WriterCommands;
using Application.Queries;
using Application.Responses;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.WriterEfCommand
{
    public class EfGetWritersCommand : EfBaseCommand, IGetWritersCommand
    {
        public EfGetWritersCommand(EfCinemakContext context) : base(context)
        {
        }

        public PagedResponse<WriterDto> Execute(WriterQuery request)
        {
            var query = Context.Writers.AsQueryable();

            query = query.Where(w => w.IsDeleted == false);

            if (request.Name != null)
                query = query.Where(w => w.Name.ToLower().Contains(request.Name.ToLower()));

            var totalCount = query.Count();

            query = query.Skip((request.PageNumber - 1) * request.PerPage).Take(request.PerPage);

            var pagesCount = (int)Math.Ceiling((double)totalCount / request.PerPage);

            return new PagedResponse<WriterDto>
            {
                CurrentPage = request.PageNumber,
                PagesCount = pagesCount,
                TotalCount = totalCount,
                Data = query.Select(w => new WriterDto
                {
                    Id = w.Id,
                    Name = w.Name
                })
            };
        }
    }
}
