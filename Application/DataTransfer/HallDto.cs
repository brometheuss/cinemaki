using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransfer
{
    public class HallDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MaximumOccupancy { get; set; }
        public IEnumerable<SeatDto> SeatsInfo { get; set; } = new List<SeatDto>();
    }
}
