using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DataTransfer
{
    public class PosterDto
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Title(Poster name)")]
        public string PosterTitle { get; set; }
        [Required]
        [Display(Name = "Alt tag")]
        public string Alt { get; set; }
        [Required]
        [Display(Name = "Name(File name)")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Movie")]
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        [Required]
        public IFormFile Image { get; set; }
    }
}
