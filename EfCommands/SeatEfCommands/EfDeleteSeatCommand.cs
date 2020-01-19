using Application.Exceptions;
using Application.ICommands.SeatCommands;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands.SeatEfCommands
{
    public class EfDeleteSeatCommand : EfBaseCommand, IDeleteSeatCommand
    {
        public EfDeleteSeatCommand(EfCinemakContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var seat = Context.Seats.Find(request);

            if (seat == null || seat.IsDeleted == true)
                throw new EntityNotFoundException("Seat");

            seat.IsDeleted = true;

            Context.SaveChanges();
        }
    }
}
