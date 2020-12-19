using Application.DataTransfer;
using Application.Exceptions;
using Application.ICommands.MovieCommands;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.MovieEfCommands
{
    public class EfGetMovieCommand : EfBaseCommand, IGetMovieCommand
    {
        public EfGetMovieCommand(EfCinemakContext context) : base(context)
        {
        }

        public int Id => 34;

        public string Name => "Get Movie using EntityFramework";

        public MovieDto Execute(int request)
        {
            var movie = Context.Movies
                .Where(m => m.Id == request)
                .Include(mg => mg.MovieGenres)
                .ThenInclude(g => g.Genre)
                .Include(mw => mw.MovieWriters)
                .ThenInclude(w => w.Writer)
                .Include(ml => ml.MovieLanguages)
                .ThenInclude(l => l.Language)
                .Include(c => c.Country)
                .Include(p => p.Production)
                .Include(r => r.Rated)
                .FirstOrDefault();

            //var query = Context.Movies
            //    .Include(mg => mg.MovieGenres)
            //    .ThenInclude(g => g.Genre);

            if (movie == null || movie.IsDeleted == true)
                throw new EntityNotFoundException("Movie");

            return new MovieDto
            {
                Id = movie.Id,
                Title = movie.Title,
                Plot = movie.Plot,
                Description = movie.Description,
                CountryId = movie.CountryId,
                ProductionId = movie.ProductionId,
                RatedId = movie.RatedId,
                DebutDate = movie.DebutDate,
                EndDate = movie.EndDate,
                LengthMinutes = movie.LengthMinutes,
                BoxOffice = movie.BoxOffice,
                Is3D = movie.Is3D,
                CountryName = movie.Country.Name,
                ProductionName = movie.Production.Name,
                RatedName = movie.Rated.Name,
                GenresInfo = movie.MovieGenres.Select(g => new MovieGenreDto
                {
                    GenreId = g.GenreId,
                    GenreName = g.Genre.Name
                }),
                WritersInfo = movie.MovieWriters.Select(w => new MovieWriterDto
                {
                    WriterId = w.WriterId,
                    Name = w.Writer.Name
                }),
                LanguagesInfo = movie.MovieLanguages.Select(l => new MovieLanguageDto
                {
                    LanguageId = l.LanguageId,
                    LanguageName = l.Language.Name
                })
            };
        }
    }
}
