﻿using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api
{
    public class JwtActor : IApplicationActor
    {
        public int Id { get; set; } 

        public string Identity { get; set; }

        public IEnumerable<int> AllowedUseCases { get; set; }
    }
}
