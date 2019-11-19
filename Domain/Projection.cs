using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Projection : BaseEntity
    {
        public DateTime DateBegin { get; set; }
        public DateTime DateEnd { get; set; }
        public int HallId { get; set; }
        public Hall Hall { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}
