using Application.DataTransfer;
using Application.ICommands.MovieCommands;
using Application.Queries;
using Application.Responses;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.MovieEfCommands
{
    public class EfGetMoviesCommand : EfBaseCommand, IGetMoviesCommand
    {
        public EfGetMoviesCommand(EfCinemakContext context) : base(context)
        {
        }

        public PagedResponse<MovieDto> Execute(MovieQuery request)
        {
            var query = Context.Movies
                .Include(mg => mg.MovieGenres)
                .ThenInclude(g => g.Genre)
                .AsQueryable();

            query = query.Where(m => m.IsDeleted == false);

            if (request.Title != null)
                query = query.Where(m => m.Title.ToLower().Contains(request.Title.ToLower()));

            var totalCount = query.Count();

            query = query.Skip((request.PageNumber - 1) * request.PerPage).Take(request.PerPage);

            var pagesCount = (int)Math.Ceiling((double)totalCount / request.PerPage);

            return new PagedResponse<MovieDto>
            {
                CurrentPage = request.PageNumber,
                PagesCount = pagesCount,
                TotalCount = totalCount,
                Data = query.Select(m => new MovieDto
                {
                    Id = m.Id,
                    Title = m.Title,
                    Description = m.Description,
                    Plot = m.Plot,
                    BoxOffice = m.BoxOffice,
                    CountryName = m.Country.Name,
                    DebutDate = m.DebutDate,
                    EndDate = m.EndDate,
                    Is3D = m.Is3D,
                    LengthMinutes = m.LengthMinutes,
                    CountryId = m.CountryId,
                    ProductionId = m.ProductionId,
                    RatedId = m.RatedId,
                    GenresInfo = m.MovieGenres.Select(g => new MovieGenreDto
                    {
                        GenreId = g.GenreId,
                        GenreName = g.Genre.Name
                    })
                })
            };
        }
    }
}
