using Application.DataTransfer;
using Application.ICommands.PosterCommands;
using Application.Queries;
using Application.Responses;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.PosterEfCommands
{
    public class EfGetPostersCommand : EfBaseCommand, IGetPostersCommand
    {
        public EfGetPostersCommand(EfCinemakContext context) : base(context)
        {
        }

        public int Id => 40;

        public string Name => "Get Posters using EntityFramework";

        public PagedResponse<PosterDto> Execute(PosterQuery request)
        {
            var query = Context.Posters
                .Include(m => m.Movie)
                .AsQueryable();

            query = query.Where(p => p.IsDeleted == false);

            if (request.PosterName != null)
                query = query.Where(p => p.PosterTitle.ToLower().Contains(request.PosterName.ToLower()));

            if (request.MovieName != null)
                query = query.Where(m => m.Movie.Title.ToLower().Contains(request.MovieName.ToLower()));

            var totalCount = query.Count();

            query = query.Skip((request.PageNumber - 1) * request.PerPage).Take(request.PerPage);

            var pagesCount = (int)Math.Ceiling((double)totalCount / request.PerPage);

            return new PagedResponse<PosterDto>
            {
                CurrentPage = request.PageNumber,
                PagesCount = pagesCount,
                TotalCount = totalCount,
                Data = query.Select(p => new PosterDto
                {
                    Id = p.Id,
                    PosterTitle = p.PosterTitle,
                    Name = p.Name,
                    Alt = p.Alt,
                    MovieId = p.MovieId,
                    MovieName = p.Movie.Title
                })
            };
        }
    }
}
