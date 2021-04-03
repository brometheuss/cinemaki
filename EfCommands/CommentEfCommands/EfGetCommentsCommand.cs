using Application.DataTransfer;
using Application.ICommands.CommentCommands;
using Application.Queries;
using Application.Responses;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.CommentEfCommands
{
    public class EfGetCommentsCommand : EfBaseCommand, IGetCommentsCommand
    {
        public EfGetCommentsCommand(EfCinemakContext context) : base(context)
        {
        }

        public int Id => 10;

        public string Name => "Get Comments using EntityFramework";

        public PagedResponse<CommentDto> Execute(CommentQuery request)
        {
            var query = Context.Comments
                .Include(m => m.Movie)
                .Include(u => u.User)
                .AsQueryable();

            query = query.Where(c => c.IsDeleted == false);

            if (request.Text != null)
                query = query.Where(c => c.Text.ToLower().Contains(request.Text.ToLower()));

            if (request.Rating != 0)
                query = query.Where(c => c.Rating == request.Rating);

            if (request.BiggerThan != 0)
                query = query.Where(c => c.Rating > request.BiggerThan);

            if (request.LessThan != 0)
                query = query.Where(c => c.Rating < request.LessThan);

            if (request.MovieId > 0)
                query = query.Where(c => c.MovieId == request.MovieId);

            if (request.MovieName != null)
                query = query.Where(c => c.Movie.Title.ToLower().Contains(request.MovieName.ToLower()));

            if (request.UserId > 0)
                query = query.Where(c => c.UserId == request.UserId);

            if (request.UserName != null)
                query = query.Where(c => c.User.Username.ToLower().Contains(request.UserName.ToLower()));

            var totalCount = query.Count();

            query = query.Skip((request.PageNumber - 1) * request.PerPage).Take(request.PerPage);

            var pagesCount = (int)Math.Ceiling((double)totalCount / request.PerPage);

            return new PagedResponse<CommentDto> 
            {
                CurrentPage = request.PageNumber,
                PagesCount = pagesCount,
                TotalCount = totalCount,
                Data = query.Select(c => new CommentDto
                {
                    Id = c.Id,
                    Text = c.Text,
                    Rating = c.Rating,
                    MovieId = c.MovieId,
                    UserId = c.UserId,
                    UserName = c.User.Username,
                    MovieName = c.Movie.Title,
                    Posted = c.CreatedAt
                })
            };
        }
    }
}
