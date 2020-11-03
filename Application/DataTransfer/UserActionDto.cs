using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransfer
{
    public class UserActionDto
    {
        public int UserId { get; set; }
        public string Action { get; set; }
        public DateTime Date { get; set; }
    }
}
