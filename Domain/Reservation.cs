using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Reservation : BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int ProjectionId { get; set; }
        public Projection Projection { get; set; }
        public ICollection<ReservationSeat> ReservationSeats { get; set; } = new List<ReservationSeat>();
    }
}
