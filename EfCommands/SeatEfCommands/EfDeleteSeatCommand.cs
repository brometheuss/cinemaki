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

        public int Id => 67;

        public string Name => "Delete Seat using EntityFramework";

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
