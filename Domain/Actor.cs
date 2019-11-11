using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Actor : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Link { get; set; }
        public ICollection<MovieActor> MovieActors { get; set; }
    }
}
