﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Production : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}
