using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransfer
{
    public class SeatDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public bool IsBroken { get; set; }
        public int HallId { get; set; }
        public string HallName { get; set; }
    }
}
