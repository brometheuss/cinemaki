using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries
{
    public class SeatQuery : BaseQuery
    {
        public string Name { get; set; }
        public int Number { get; set; }
        public bool IsBroken { get; set; }
        public int HallId { get; set; }
    }
}
