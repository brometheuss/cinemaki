using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Language : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<MovieLanguage> MovieLanguages { get; set; }
    }
}
