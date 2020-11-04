using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries
{
    public class LogQuery : BaseQuery
    {
        public int UserId { get; set; }
        public string Action { get; set; }
        public DateTime? Date { get; set; }
        public bool? Success { get; set; }
        public DateTime? DateAfter { get; set; }
        public DateTime? DateBefore { get; set; }
    }
}
