using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DataTransfer
{
    public class ActorDto
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "First name")]
        [RegularExpression(@"^[A-Z][a-z]{1,30}(\s[A-Z][a-z]{1,30})*$", ErrorMessage = "Must have a capital letter and be at least 2 letters long.")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last name")]
        [RegularExpression(@"^[A-Z][a-z]{1,30}(\s[A-Z][a-z]{1,30})*$", ErrorMessage = "Must have a capital letter and be at least 2 letters long.")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Part of URL after 'www.imdb.com/name/'")]
        [RegularExpression(@"^[A-z0-9]{4,}$", ErrorMessage = "Must be at least 4 letters long.")]
        public string Link { get; set; }
    }
}
