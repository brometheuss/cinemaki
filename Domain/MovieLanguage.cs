﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class MovieLanguage 
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int LanguageId { get; set; }

        public Movie Movie { get; set; }
        public Language Language { get; set; }
    }
}
