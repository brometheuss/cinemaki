using Application.Exceptions;
using Application.ICommands.ActorCommands;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands.ActorEfCommands
{
    public class EfDeleteActorCommand : EfBaseCommand, IDeleteActorCommand
    {
        public EfDeleteActorCommand(EfCinemakContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var actor = Context.Actors.Find(request);

            if(actor == null || actor.IsDeleted == true)
                throw new EntityNotFoundException("Actor");

            actor.IsDeleted = true;

            Context.SaveChanges();
        }
    }
}
