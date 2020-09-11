using Application.DataTransfer;
using Application.ICommands.ReservationCommands;
using Domain;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.ReservationEfCommands
{
    public class EfAddReservationCommand : EfBaseCommand, IAddReservationCommand
    {
        public EfAddReservationCommand(EfCinemakContext context) : base(context)
        {
        }

        public int Id => 56;

        public string Name => "Create Reservation using EntityFramework";

        public void Execute(ReservationDto request)
        {
            //broj zauzetih sedista za konkretnu halu, na osnovu projection ID
            var seatIds = Context.Projections
                .Include(r => r.Reservations)
                .ThenInclude(rs => rs.ReservationSeats)
                .Where(x => x.Id == request.ProjectionId)
                .Select(x => x.Reservations
                    .Select(a => a.ReservationSeats
                        .Select(s => s.SeatId)));

            //broj zauzetih sedista na osnovu query-ja gore
            var seatsOccup = seatIds.Count();
            //broj rezervisanih sedista od strane klijenta
            var seatsReserved = request.ReservationSeats.Count();
            //var seatsReserved = request.SeatsInfo.Count();

            //pronaci maksimalan broj sedista za neku halu, na osnovu ID projekcije
            var hall = Context.Projections
                .Include(h => h.Hall)
                .Where(p => p.Id == request.ProjectionId);

            //ako je broj zauzetih sedista i broj sedista koje klijent hoce da rezervise veci od max broja sedista u hali, baciti exception
            if (hall.Any(h => h.Hall.MaximumOccupancy < seatsOccup + seatsReserved))
                throw new Exception("Maximum number of tickets already reserved.");

            //max za poslednje sediste ili da prebrojimo ukupan broj sa count
            //preko projekcije pristupampo hall da proverimo max broj sedista za halu
                

            var reservation = new Reservation
            {
                ProjectionId = request.ProjectionId,
                UserId = request.UserId,
            };

            Context.Reservations.Add(reservation);

            request.ReservationSeats.ForEach(id =>
            {
                reservation.ReservationSeats.Add(new ReservationSeat
                {
                    SeatId = id
                });
            });

            Context.SaveChanges();
        }
    }
}
