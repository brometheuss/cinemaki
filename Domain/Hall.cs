using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Hall : BaseEntity
    {
        public string Name { get; set; }
        public int MaximumOccupancy { get; set; }
        public ICollection<Seat> Seats { get; set; }
        public ICollection<Projection> Projections { get; set; }
    }
}
