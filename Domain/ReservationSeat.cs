using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class ReservationSeat
    {
        public int Id { get; set; }
        public int ReservationId { get; set; }
        public int SeatId { get; set; }

        public Reservation Reservation { get; set; }
        public Seat Seat { get; set; }
    }
}
