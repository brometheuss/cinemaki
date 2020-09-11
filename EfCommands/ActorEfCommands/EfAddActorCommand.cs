using Application.DataTransfer;
using Application.Exceptions;
using Application.ICommands.ActorCommands;
using Domain;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.ActorEfCommands
{
    public class EfAddActorCommand : EfBaseCommand, IAddActorCommand
    {
        public EfAddActorCommand(EfCinemakContext context) : base(context)
        {
        }

        public int Id => 1;

        public string Name => "Create Actor using EntityFramework";

        public void Execute(ActorDto request)
        {
            if (Context.Actors.Any(a => a.Link == request.Link))
                throw new EntityAlreadyExistsException("Actor");

            Context.Actors.Add(new Actor
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Link = request.Link
            });

            Context.SaveChanges();
        }
    }
}
