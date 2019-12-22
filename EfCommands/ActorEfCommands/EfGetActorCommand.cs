using Application.DataTransfer;
using Application.Exceptions;
using Application.ICommands.ActorCommands;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands.ActorEfCommands
{
    public class EfGetActorCommand : EfBaseCommand, IGetActorCommand
    {
        public EfGetActorCommand(EfCinemakContext context) : base(context)
        {
        }

        public ActorDto Execute(int request)
        {
            var actor = Context.Actors.Find(request);

            if (actor == null || actor.IsDeleted == true)
                throw new EntityNotFoundException("Actor");

            return new ActorDto
            {
                Id = actor.Id,
                FirstName = actor.FirstName,
                LastName = actor.LastName,
                Link = actor.Link
            };
        }
    }
}
