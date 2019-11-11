using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class MovieWriter
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int WriterId { get; set; }

        public Movie Movie { get; set; }
        public Writer Writer { get; set; }
    }
}
