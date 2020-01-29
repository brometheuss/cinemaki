using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries
{
    public class HallQuery : BaseQuery
    {
        public string Name { get; set; }
        public int MaximumOccupancy { get; set; }
        public int MinimumOccupancy { get; set; }
    }
}
