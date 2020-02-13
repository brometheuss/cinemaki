using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DataTransfer
{
    public class RoleDto
    {
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"^[A-Z][a-z]{1,}(\s[A-z]{1,})*$", ErrorMessage = "Must have a capital letter and be at least 2 letters long.")]
        public string Name { get; set; }
    }
}
