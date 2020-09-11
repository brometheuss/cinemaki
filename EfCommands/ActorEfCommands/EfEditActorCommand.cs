using Application.DataTransfer;
using Application.Exceptions;
using Application.ICommands.ActorCommands;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.ActorEfCommands
{
    public class EfEditActorCommand : EfBaseCommand, IEditActorCommand
    {
        public EfEditActorCommand(EfCinemakContext context) : base(context)
        {
        }

        public int Id => 3;

        public string Name => "Edit Actor using EntityFramework";

        public void Execute(ActorDto request)
        {
            var actor = Context.Actors.Find(request.Id);

            if (actor == null || actor.IsDeleted == true)
                throw new EntityNotFoundException("Actor");

            if (actor.Link != request.Link && Context.Actors.Any(a => a.Link.ToLower() == request.Link.ToLower()))
                throw new EntityAlreadyExistsException("Actor");

            actor.FirstName = request.FirstName;
            actor.LastName = request.LastName;
            actor.Link = request.Link;

            Context.SaveChanges();
        }
    }
}
