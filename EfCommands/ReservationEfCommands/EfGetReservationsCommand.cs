﻿using Application.DataTransfer;
using Application.ICommands.ReservationCommands;
using Application.Queries;
using Application.Responses;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.ReservationEfCommands
{
    public class EfGetReservationsCommand : EfBaseCommand, IGetReservationsCommand
    {
        public EfGetReservationsCommand(EfCinemakContext context) : base(context)
        {
        }

        public int Id => 59;

        public string Name => "Get Reservation using EntityFramework";

        public PagedResponse<ReservationDto> Execute(ReservationQuery request)
        {
            var query = Context.Reservations
                .Include(u => u.User)
                .Include(rs => rs.ReservationSeats)
                .ThenInclude(s => s.Seat)
                .ThenInclude(h => h.Hall)
                .Include(p => p.Projection)
                .ThenInclude(m => m.Movie)
                .AsQueryable();

            query = query.Where(x => x.IsDeleted == false);

            if (request.ProjectionId != 0)
                query = query.Where(x => x.ProjectionId == request.ProjectionId);

            if (request.HallId != 0)
                query = query.Where(x => x.ReservationSeats.Any(s => s.Seat.HallId == request.HallId));

            var totalCount = query.Count();

            query = query.Skip((request.PageNumber - 1) * request.PerPage).Take(request.PerPage);

            var pagesCount = (int)Math.Ceiling((double)totalCount / request.PerPage);

            return new PagedResponse<ReservationDto>
            {
                CurrentPage = request.PageNumber,
                PagesCount = pagesCount,
                TotalCount = totalCount,
                Data = query.Select(x => new ReservationDto
                {
                    Id = x.Id,
                    ProjectionId = x.ProjectionId,
                    MovieId = x.Projection.MovieId,
                    UserId = x.UserId,
                    Username = x.User.Username,
                    HallId = x.Projection.HallId,
                    //MovieName
                    SeatsInfo = x.ReservationSeats.Select(s => new ReservationSeatDto
                    {
                        SeatId = s.Seat.Id,
                        SeatNumber = s.Seat.Number,
                        SeatBroken = s.Seat.IsBroken,
                        SeatHallId = s.Seat.HallId,
                        SeatName = s.Seat.Name  
                    })
                })
            };
        }
    }
}