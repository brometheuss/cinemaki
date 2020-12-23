using Application.DataTransfer;
using Application.Exceptions;
using Application.ICommands.ReservationCommands;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.ReservationEfCommands
{
    public class EfGetReservationCommand : EfBaseCommand, IGetReservationCommand
    {
        public EfGetReservationCommand(EfCinemakContext context) : base(context)
        {
        }

        public int Id => 58;

        public string Name => "Get Reservation using EntityFramework";

        public ReservationDto Execute(int request)
        {
            var res = Context.Reservations
                .Where(x => x.Id == request)
                .Include(rs => rs.ReservationSeats)
                .ThenInclude(s => s.Seat)
                .Include(p => p.Projection)
                .ThenInclude(m => m.Movie)
                .Include(u => u.User)
                .FirstOrDefault();

            if (res == null || res.IsDeleted == true)
                throw new EntityNotFoundException("Reservation");

            return new ReservationDto
            {
                Id = res.Id,
                UserId = res.UserId,
                ProjectionId = res.ProjectionId,
                Username = res.User.Username,
                MovieId = res.Projection.MovieId,
                MovieName = res.Projection.Movie.Title,
                ProjectionBegin = res.Projection.DateBegin,
                ProjectionEnd = res.Projection.DateEnd,
                HallId = res.Projection.HallId,
                SeatsInfo = res.ReservationSeats.Select(rs => new ReservationSeatDto
                {
                    SeatId = rs.Id,
                    SeatBroken = rs.Seat.IsBroken,
                    SeatName = rs.Seat.Name,
                    SeatNumber = rs.Seat.Number,
                    SeatHallId = rs.Seat.HallId
                })
            };
        }
    }
}
