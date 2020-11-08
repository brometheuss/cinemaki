using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DataTransfer
{
    public class LogDto
    {
        [Display(Name = "Log Id")]
        public int Id { get; set; }
        [Display(Name = "User info")]
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Action { get; set; }
        public bool Success { get; set; }
        [Display(Name = "Date executed")]
        public DateTime Date { get; set; }
    }
}
