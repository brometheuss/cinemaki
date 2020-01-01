using Application.DataTransfer;
using Application.ICommands.CommentCommands;
using Application.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands.CommentEfCommands
{
    public class EfEditCommentCommand : EfBaseCommand, IEditCommentCommand
    {
        public EfEditCommentCommand(EfCinemakContext context) : base(context)
        {
        }

        public void Execute(CommentDto request)
        {
            var comment = Context.Comments.Find(request.Id);

            if (comment == null || comment.IsDeleted == true)
                throw new EntityNotFoundException("Comment");

            comment.Text = request.Text;
            comment.Rating = request.Rating;

            Context.SaveChanges();
        }
    }
}
