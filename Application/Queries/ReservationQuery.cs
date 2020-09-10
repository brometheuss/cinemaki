using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries
{
    public class ReservationQuery : BaseQuery
    {
        public int MovieId { get; set; }
        public int HallId { get; set; }
        public int ProjectionId { get; set; }
        public int UserId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
