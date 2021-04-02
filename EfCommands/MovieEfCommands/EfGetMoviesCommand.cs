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

        public int Id => 35;

        public string Name => "Get Movies using EntityFramework";

        public PagedResponse<MovieDto> Execute(MovieQuery request)
        {
            var query = Context.Movies
                .Include(p => p.Posters)
                .Include(mg => mg.MovieGenres)
                .ThenInclude(g => g.Genre)
                .Include(ma => ma.MovieActors)
                .ThenInclude(a => a.Actor)
                .Include(mw => mw.MovieWriters)
                .ThenInclude(w => w.Writer)
                .AsQueryable();

            query = query.Where(m => m.IsDeleted == false);

            if (request.Title != null)
                query = query.Where(m => m.Title.ToLower().Contains(request.Title.ToLower()));

            if (request.Description != null)
                query = query.Where(m => m.Description.ToLower().Contains(request.Description.ToLower()));

            if (request.LengthMinutes > 0)
                query = query.Where(m => m.LengthMinutes == request.LengthMinutes);

            if (request.Is3D != null)
                query = query.Where(m => m.Is3D == request.Is3D);

            if (request.BoxOffice >= 0)
                query = query.Where(m => m.BoxOffice > request.BoxOffice);

            if (request.BoxOfficeSmallerThan > 0)
                query = query.Where(m => m.BoxOffice < request.BoxOfficeSmallerThan);

            if (request.DebutDate != null)
                query = query.Where(m => m.DebutDate > request.DebutDate);

            if (request.EndDate != null)
                query = query.Where(m => m.EndDate < request.EndDate);

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
                    ProductionName = m.Production.Name,
                    RatedName = m.Rated.Name,
                    DebutDate = m.DebutDate,
                    EndDate = m.EndDate,
                    Is3D = m.Is3D,
                    LengthMinutes = m.LengthMinutes,
                    CountryId = m.CountryId,
                    ProductionId = m.ProductionId,
                    RatedId = m.RatedId,
                    ImageFiles = m.Posters.Select(p => new PosterDto
                    {
                        Name = p.Name,
                        Alt = p.Alt
                    }),
                    GenresInfo = m.MovieGenres.Select(g => new MovieGenreDto
                    {
                        GenreId = g.GenreId,
                        GenreName = g.Genre.Name
                    }),
                    ActorsInfo = m.MovieActors.Select(a => new MovieActorDto
                    {
                        ActorId = a.Actor.Id,
                        FirstName = a.Actor.FirstName,
                        LastName = a.Actor.LastName,
                        Link = a.Actor.Link
                    }),
                    WritersInfo = m.MovieWriters.Select(w => new MovieWriterDto
                    {
                        WriterId = w.Writer.Id,
                        Name = w.Writer.Name
                    }),
                    LanguagesInfo = m.MovieLanguages.Select(l => new MovieLanguageDto
                    {
                        LanguageId = l.Language.Id,
                        LanguageName = l.Language.Name
                    })
                })
            };
        }
    }
}
