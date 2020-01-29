using Application.Exceptions;
using Application.ICommands.HallCommands;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands.HallEfCommands
{
    public class EfDeleteHallCommand : EfBaseCommand, IDeleteHallCommand
    {
        public EfDeleteHallCommand(EfCinemakContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var hall = Context.Halls.Find(request);

            if (hall == null || hall.IsDeleted == true)
                throw new EntityNotFoundException("Hall");

            hall.IsDeleted = true;

            Context.SaveChanges();
        }
    }
}
