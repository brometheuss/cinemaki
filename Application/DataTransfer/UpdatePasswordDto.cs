using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DataTransfer
{
    public class UpdatePasswordDto
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Old password")]
        public string OldPassword { get; set; }
        [Required]
        [Display(Name = "New password")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$", ErrorMessage = "Must have atleast 8 characters with 1 uppercase, 1 lowercase character and 1 number.")]
        public string NewPassword { get; set; }
        [Required]
        [Display(Name = "Confirm password")]
        [Compare(nameof(NewPassword), ErrorMessage = "Passwords don't match.")]
        public string ConfirmNewPassword { get; set; }
    }
}
