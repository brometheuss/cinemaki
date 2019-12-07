using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries
{
    public class BaseQuery
    {
        public int PerPage { get; set; } = 10;
        public int PageNumber { get; set; } = 1;
    }
}
