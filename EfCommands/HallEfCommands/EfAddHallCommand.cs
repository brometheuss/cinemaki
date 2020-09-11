using Application.DataTransfer;
using Application.Exceptions;
using Application.ICommands.HallCommands;
using Domain;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.HallEfCommands
{
    public class EfAddHallCommand : EfBaseCommand, IAddHallCommand
    {
        public EfAddHallCommand(EfCinemakContext context) : base(context)
        {
        }

        public int Id => 21;

        public string Name => "Create Hall using EntityFramework";

        public void Execute(HallDto request)
        {
            if (Context.Halls.Any(h => h.Name.ToLower() == request.Name.ToLower()))
                throw new EntityAlreadyExistsException("Hall");

            Context.Halls.Add(new Hall
            {
                Name = request.Name,
                MaximumOccupancy = request.MaximumOccupancy
            });

            Context.SaveChanges();
        }
    }
}
