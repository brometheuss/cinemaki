using Application.DataTransfer;
using Application.Exceptions;
using Application.ICommands.HallCommands;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.HallEfCommands
{
    public class EfEditHallCommand : EfBaseCommand, IEditHallCommand
    {
        public EfEditHallCommand(EfCinemakContext context) : base(context)
        {
        }

        public int Id => 23;

        public string Name => "Edit Hall using EntityFramework";

        public void Execute(HallDto request)
        {
            var hall = Context.Halls.Find(request.Id);

            if (hall == null || hall.IsDeleted == true)
                throw new EntityNotFoundException("Hall");

            if (request.Name.ToLower() != hall.Name.ToLower() && Context.Halls.Any(h => h.Name.ToLower() == request.Name.ToLower()))
                throw new EntityAlreadyExistsException("Hall with that name");

            hall.Name = request.Name;
            hall.MaximumOccupancy = request.MaximumOccupancy;

            Context.SaveChanges();
        }
    }
}
