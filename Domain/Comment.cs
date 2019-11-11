using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Comment : BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public string Text { get; set; }
        public decimal Rating { get; set; }
    }
}
