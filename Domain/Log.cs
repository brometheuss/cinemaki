using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Log
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Action { get; set; }
        public DateTime Date { get; set; }
        public bool Success { get; set; }
        public User User { get; set; }
    }
}
