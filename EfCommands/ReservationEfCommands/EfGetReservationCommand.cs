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
                .Include(rs => rs.ReservationSeats)
                .FirstOrDefault();

            if (res == null || res.IsDeleted == true)
                throw new EntityNotFoundException("Reservation");

            return new ReservationDto
            {
                Id = res.Id,
                UserId = res.UserId,
                ProjectionId = res.ProjectionId
            };
        }
    }
}
