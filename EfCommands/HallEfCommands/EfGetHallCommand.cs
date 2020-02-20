using Application.DataTransfer;
using Application.Exceptions;
using Application.ICommands.HallCommands;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands.HallEfCommands
{
    public class EfGetHallCommand : EfBaseCommand, IGetHallCommand
    {
        public EfGetHallCommand(EfCinemakContext context) : base(context)
        {
        }

        public HallDto Execute(int request)
        {
            var hall = Context.Halls.Find(request);

            if (hall == null || hall.IsDeleted == true)
                throw new EntityNotFoundException("Hall");

            return new HallDto
            {
                Id = hall.Id,
                Name = hall.Name,
                MaximumOccupancy = hall.MaximumOccupancy
            };
        }
    }
}
