﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Country : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}
