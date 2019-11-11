using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Poster : BaseEntity
    {
        public string PosterTitle { get; set; }
        public string Alt { get; set; }
        public string Name { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}
