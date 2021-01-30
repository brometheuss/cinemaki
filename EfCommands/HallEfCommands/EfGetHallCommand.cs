using Application.DataTransfer;
using Application.Exceptions;
using Application.ICommands.HallCommands;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.HallEfCommands
{
    public class EfGetHallCommand : EfBaseCommand, IGetHallCommand
    {
        public EfGetHallCommand(EfCinemakContext context) : base(context)
        {
        }

        public int Id => 24;

        public string Name => "Get Hall using EntityFramework";

        public HallDto Execute(int request)
        {
            var hall = Context.Halls
                .Where(h => h.Id == request)
                .Include(s => s.Seats)
                .FirstOrDefault();
                

            if (hall == null || hall.IsDeleted == true)
                throw new EntityNotFoundException("Hall");

            return new HallDto
            {
                Id = hall.Id,
                Name = hall.Name,
                MaximumOccupancy = hall.MaximumOccupancy,
                SeatsInfo = hall.Seats.Select(s => new SeatDto
                {
                    Name = s.Name,
                    Number = s.Number,
                    IsBroken = s.IsBroken,
                    Id = s.Id,
                    HallId = s.HallId
                })
            };
        }
    }
}
