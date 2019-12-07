using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries
{
    public class MovieQuery : BaseQuery
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int LengthMinutes { get; set; }
        public string Plot { get; set; }
        public decimal BoxOffice { get; set; }
        public DateTime DebutDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Is3D { get; set; }
    }
}
