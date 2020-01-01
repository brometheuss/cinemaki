using Application.DataTransfer;
using Application.Exceptions;
using Application.ICommands.CommentCommands;
using Domain;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.CommentEfCommands
{
    public class EfAddCommentCommand : EfBaseCommand, IAddCommentCommand
    {
        public EfAddCommentCommand(EfCinemakContext context) : base(context)
        {
        }

        public void Execute(CommentDto request)
        {
            var user = Context.Users.Find(request.UserId);
            var movie = Context.Movies.Find(request.MovieId);

            if (user == null || user.IsDeleted == true)
                throw new EntityNotFoundException("User");

            if (movie == null || movie.IsDeleted == true)
                throw new EntityNotFoundException("Movie");

            if (Context.Comments.Any(cid => cid.UserId == request.UserId) && Context.Comments.Any(mid => mid.MovieId == request.MovieId))
                throw new EntityAlreadyHasAnEntryException("comment.");

            Context.Comments.Add(new Comment
            {
                Text = request.Text,
                UserId = request.UserId,
                MovieId = request.MovieId,
                Rating = request.Rating
            });

            Context.SaveChanges();
        }
    }
}
