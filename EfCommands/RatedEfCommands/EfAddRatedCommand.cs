using Application.DataTransfer;
using Application.Exceptions;
using Application.ICommands.RatedCommands;
using Domain;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.RatedEfCommands
{
    public class EfAddRatedCommand : EfBaseCommand, IAddRatedCommand
    {
        public EfAddRatedCommand(EfCinemakContext context) : base(context)
        {
        }

        public void Execute(RatedDto request)
        {
            if (Context.Rateds.Any(r => r.Name.ToLower() == request.Name.ToLower()))
                throw new EntityAlreadyExistsException("Rating");

            Context.Rateds.Add(new Rated
            {
                Name = request.Name,
            });

            Context.SaveChanges();
        }
    }
}
