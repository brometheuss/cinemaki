﻿using Application.DataTransfer;
using Application.Exceptions;
using Application.ICommands.SeatCommands;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.SeatEfCommands
{
    public class EfGetSeatCommand : EfBaseCommand, IGetSeatCommand
    {
        public EfGetSeatCommand(EfCinemakContext context) : base(context)
        {
        }

        public SeatDto Execute(int request)
        {
            var seat = Context.Seats
                .Include(h => h.Hall)
                .FirstOrDefault();

            if (seat == null || seat.IsDeleted == true)
                throw new EntityNotFoundException("Seat");

            return new SeatDto
            {
                Id = seat.Id,
                HallId = seat.HallId,
                IsBroken = seat.IsBroken,
                Name = seat.Name,
                Number = seat.Number,
                HallName = seat.Hall.Name
            };
        }
    }
}
