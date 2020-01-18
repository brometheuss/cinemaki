using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransfer
{
    public class ProjectionDto
    {
        public int Id { get; set; }
        public DateTime DateBegin { get; set; }
        public DateTime DateEnd { get; set; }
        public int HallId { get; set; }
        public int MovieId { get; set; }
    }
}
