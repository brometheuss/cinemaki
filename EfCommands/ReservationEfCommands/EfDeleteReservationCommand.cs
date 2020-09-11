using Application.Exceptions;
using Application.ICommands.ReservationCommands;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands.ReservationEfCommands
{
    public class EfDeleteReservationCommand : EfBaseCommand, IDeleteReservationCommand
    {
        public EfDeleteReservationCommand(EfCinemakContext context) : base(context)
        {
        }

        public int Id => 57;

        public string Name => "Delete REservation using EntityFramework";

        public void Execute(int request)
        {
            var reservation = Context.Reservations.Find(request);

            if (reservation == null || reservation.IsDeleted == true)
                throw new EntityNotFoundException("Reservation");

            reservation.IsDeleted = true;

            Context.SaveChanges();
        }
    }
}
