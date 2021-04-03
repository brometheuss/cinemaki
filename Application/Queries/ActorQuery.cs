﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries
{
    public class ActorQuery : BaseQuery
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int MovieId { get; set; }
        public string MovieName { get; set; }
    }
}
