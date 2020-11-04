using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransfer
{
    public class LogDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Action { get; set; }
        public bool Success { get; set; }
        public DateTime Date { get; set; }
    }
}
