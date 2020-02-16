using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DataTransfer
{
    public class CountryDto
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Country name")]
        [RegularExpression(@"^[A-Z][a-z]{1,30}(\s[A-Z][a-z]{1,30})*$", ErrorMessage = "Must have a capital letter and be at least 2 letters long.")]
        public string Name { get; set; }
    }
}
