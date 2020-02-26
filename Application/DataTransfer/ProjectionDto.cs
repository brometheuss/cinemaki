using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DataTransfer
{
    public class ProjectionDto
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Projection Start")]
        public DateTime DateBegin { get; set; }
        [Required]
        [Display(Name = "Projection End")]
        public DateTime DateEnd { get; set; }
        [Required]
        [Display(Name = "Hall Id")]
        public int HallId { get; set; }
        [Display(Name = "Hall Name")]
        public string HallName { get; set; }
        [Required]
        [Display(Name = "Movie Id")]
        public int MovieId { get; set; }
        [Display(Name = "Movie Name")]
        public string MovieName { get; set; }
    }
}
