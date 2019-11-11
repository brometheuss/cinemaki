using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Rated : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}
