using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransfer
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public decimal Rating { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int MovieId { get; set; }
        public string MovieName { get; set; }
    }
}
