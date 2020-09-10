using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransfer
{
    public class ReservationSeatDto
    {
        public int SeatId { get; set; }
        public string SeatName { get; set; }
        public int SeatNumber { get; set; }
        public bool SeatBroken { get; set; }
        public int SeatHallId { get; set; }
    }
}
