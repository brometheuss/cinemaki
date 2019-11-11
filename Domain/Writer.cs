using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Writer : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<MovieWriter> MovieWriters { get; set; }
    }
}
