using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DataTransfer
{
    public class SignUpUserDto
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
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$", ErrorMessage = "Must have atleast 8 characters with 1 uppercase, 1 lowercase character and 1 number.")]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Confirm Password")]
        [Compare(nameof(Password), ErrorMessage = "Passwords don't match.")]
        public string ConfirmPassword { get; set; }
    }
}
