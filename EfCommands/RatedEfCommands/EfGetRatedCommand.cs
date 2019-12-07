using Application.DataTransfer;
using Application.Exceptions;
using Application.ICommands.RatedCommands;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands.RatedEfCommands
{
    public class EfGetRatedCommand : EfBaseCommand, IGetRatedCommand
    {
        public EfGetRatedCommand(EfCinemakContext context) : base(context)
        {
        }

        public RatedDto Execute(int request)
        {
            var rated = Context.Rateds.Find(request);

            if (rated == null || rated.IsDeleted == true)
                throw new EntityNotFoundException("Rating");

            return new RatedDto
            {
                Id = rated.Id,
                Name = rated.Name
            };
        }
    }
}
