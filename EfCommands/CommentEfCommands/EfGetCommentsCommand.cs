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
                    MovieName = c.Movie.Title
                })
            };
        }
    }
}
