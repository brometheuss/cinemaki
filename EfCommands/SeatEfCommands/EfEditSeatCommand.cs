using Application.DataTransfer;
using Application.Exceptions;
using Application.ICommands.SeatCommands;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.SeatEfCommands
{
    public class EfEditSeatCommand : EfBaseCommand, IEditSeatCommand
    {
        public EfEditSeatCommand(EfCinemakContext context) : base(context)
        {
        }

        public void Execute(SeatDto request)
        {
            var seat = Context.Seats.Find(request.Id);

            if (seat == null || seat.IsDeleted == true)
                throw new EntityNotFoundException("Seat");

            if (Context.Halls.Where(h => h.Id == request.HallId).Any(h => h.MaximumOccupancy <= Context.Seats.Where(s => s.HallId == request.HallId).Count()))
                throw new Exception("Maximum hall occupancy reached.");

            if (seat.Name.ToLower() != request.Name.ToLower() || seat.Number != request.Number && Context.Seats.Any(s => s.Name.ToLower().Contains(request.Name.ToLower()) && s.Number == request.Number && s.HallId == request.HallId))
                throw new EntityAlreadyExistsException("Seat");

            seat.HallId = request.HallId;
            seat.Name = request.Name;
            seat.Number = request.Number;
            seat.IsBroken = request.IsBroken;

            Context.SaveChanges();
        }
    }
}
