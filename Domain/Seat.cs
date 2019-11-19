using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Seat : BaseEntity
    {
        public string Name { get; set; }
        public int Number { get; set; }
        public bool IsBroken { get; set; }
        public int HallId { get; set; }
        public Hall Hall { get; set; }
        public ICollection<ReservationSeat> ReservationSeats { get; set; }
    }
}
