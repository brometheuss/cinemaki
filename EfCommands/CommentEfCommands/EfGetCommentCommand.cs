using Application.DataTransfer;
using Application.Exceptions;
using Application.ICommands.CommentCommands;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.CommentEfCommands
{
    public class EfGetCommentCommand : EfBaseCommand, IGetCommentCommand
    {
        public EfGetCommentCommand(EfCinemakContext context) : base(context)
        {
        }

        public int Id => 9;

        public string Name => "Get Comment using EntityFramework";

        public CommentDto Execute(int request)
        {
            var comment = Context.Comments.Find(request);

            if (comment == null || comment.IsDeleted == true)
                throw new EntityNotFoundException("Comment");

            return new CommentDto
            {
                Id = comment.Id,
                Text = comment.Text,
                Rating = comment.Rating,
                UserId = comment.UserId,
                MovieId = comment.MovieId,
            };
        }
    }
}
