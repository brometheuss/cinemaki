using Application.DataTransfer;
using Application.Exceptions;
using Application.ICommands.SeatCommands;
using Domain;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.SeatEfCommands
{
    public class EfAddSeatCommand : EfBaseCommand, IAddSeatCommand
    {
        public EfAddSeatCommand(EfCinemakContext context) : base(context)
        {
        }

        public int Id => 66;

        public string Name => "Create Seat using EntityFramework";

        public void Execute(SeatDto request)
        {
            if (Context.Halls.Where(h => h.Id == request.HallId).Any(h => h.MaximumOccupancy <= Context.Seats.Where(s => s.HallId == request.HallId).Count()))
                throw new Exception("Maximum hall occupancy reached.");

            if (Context.Seats.Any(s => s.Name.ToLower().Contains(request.Name.ToLower()) && s.HallId == request.HallId && s.Number == request.Number))
                throw new EntityAlreadyExistsException("Seat with that Name");

            Context.Seats.Add(new Seat
            {
                 HallId = request.HallId,
                 Name = request.Name,
                 Number = request.Number,
                 IsBroken = request.IsBroken
            });

            Context.SaveChanges();
        }
    }
}
