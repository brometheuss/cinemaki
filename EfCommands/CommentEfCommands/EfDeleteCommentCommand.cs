using Application.Exceptions;
using Application.ICommands.CommentCommands;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands.CommentEfCommands
{
    public class EfDeleteCommentCommand : EfBaseCommand, IDeleteCommentCommand
    {
        public EfDeleteCommentCommand(EfCinemakContext context) : base(context)
        {
        }

        public int Id => 7;

        public string Name => "Delete Comment using EntityFramework";

        public void Execute(int request)
        {
            var comment = Context.Comments.Find(request);

            if (comment == null || comment.IsDeleted == true)
                throw new EntityNotFoundException("Comment");

            comment.IsDeleted = true;

            Context.SaveChanges();
        }
    }
}
