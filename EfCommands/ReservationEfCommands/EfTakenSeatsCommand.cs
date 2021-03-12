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
            var reservations = Context.Reservations
                .Include(rs => rs.ReservationSeats)
                .ThenInclude(s => s.Seat)
                .ThenInclude(s => s.Hall)
                .Where(r => r.ProjectionId == request);

            if(reservations == null)
            {
                throw new EntityNotFoundException("Reservation");
            }

            List<SeatDto> seatList = new List<SeatDto>();

            foreach(var reservation in reservations)
            {
                var seats = reservation.ReservationSeats.Select(s => new SeatDto
                {
                    Id = s.SeatId,
                    Name = s.Seat.Name,
                    Number = s.Seat.Number,
                    IsBroken = s.Seat.IsBroken,
                    HallId = s.Seat.HallId,
                    HallName = s.Seat.Hall.Name
                });
                foreach(var seat in seats)
                {
                    seatList.Add(seat);
                }
            }

            return seatList;
        }
    }
}
