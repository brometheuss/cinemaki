using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DataTransfer
{
    public class AddUserDto
    {
        [Required]
        [Display(Name = "First name")]
        [RegularExpression(@"^[A-Z][a-z]{1,30}(\s[A-Z][a-z]{1,30})*$", ErrorMessage = "Must have a capital letter and be at least 2 letters long.")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last name")]
        [RegularExpression(@"^[A-Z][a-z]{1,30}(\s[A-Z][a-z]{1,30})*$", ErrorMessage = "Must have a capital letter and be at least 2 letters long.")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Username")]
        [RegularExpression(@"^[A-z0-9]{3,30}$", ErrorMessage = "Must be at least 3 letters long, and no special characters allowed.")]
        public string Username { get; set; }
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Password")]
        [RegularExpression(@"^[A-Z][A-z0-9\s]{7,50}$", ErrorMessage = "Must have an uppercase letter and be at least 8 letters long.")]
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        [Required]
        [Display(Name = "Role")]
        public int RoleId { get; set; }
    }
}
