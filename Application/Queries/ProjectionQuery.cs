using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries
{
    public class ProjectionQuery : BaseQuery
    {
        public DateTime? BeginsAfter { get; set; }
        public DateTime? EndsBefore { get; set; }
        public string MovieName { get; set; }
        public string HallName { get; set; }
        public int MovieId { get; set; }
    }
}
