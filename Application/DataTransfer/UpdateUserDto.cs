using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DataTransfer
{
    public class UpdateUserDto
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
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }
        
        [Display(Name = "Role")]
        public string RoleName { get; set; }
        public int RoleId { get; set; }
        
        public string Password { get; set; }
        
        public string ConfirmPassword { get; set; }
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }
    }
}
