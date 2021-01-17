using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries
{
    public class PosterQuery : BaseQuery
    {
        public int MovieId { get; set; }
        public string PosterName { get; set; }
        public string MovieName { get; set; }
    }
}
