using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries
{
    public class CommentQuery : BaseQuery
    {
        public string Text { get; set; }
        public decimal Rating { get; set; }
        public decimal BiggerThan { get; set; }
        public decimal LessThan { get; set; }
        public string UserName { get; set; }
        public string MovieName { get; set; }
    }
}
