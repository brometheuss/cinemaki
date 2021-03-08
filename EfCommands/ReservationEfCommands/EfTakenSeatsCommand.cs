using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.DataTransfer;
using Application.Exceptions;
using Application.ICommands.ReservationCommands;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;

namespace EfCommands.ReservationEfCommands
{
    public class EfTakenSeatsCommand : EfBaseCommand, ITakenSeatsCommand
    {
        public EfTakenSeatsCommand(EfCinemakContext context) : base(context)
        {
        }

        public int Id => throw new NotImplementedException();

        public string Name => throw new NotImplementedException();

        public IEnumerable<SeatDto> Execute(int request)
        {
            var reservation = Context.Reservations
                .Include(rs => rs.ReservationSeats)
                .ThenInclude(s => s.Seat)
                .ThenInclude(s => s.Hall)
                .FirstOrDefault(r => r.ProjectionId == request);

            if(reservation == null)
            {
                throw new EntityNotFoundException("Reservation");
            }

            return reservation.ReservationSeats.Select(x => new SeatDto
            {
                Id = x.SeatId,
                Name = x.Seat.Name,
                Number = x.Seat.Number,
                IsBroken = x.Seat.IsBroken,
                HallId = x.Seat.HallId,
                HallName = x.Seat.Hall.Name
            });
            
        }
    }
}
