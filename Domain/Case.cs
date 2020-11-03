using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Case : BaseEntity
    {
        public int Number { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
