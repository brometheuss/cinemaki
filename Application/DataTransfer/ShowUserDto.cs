using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DataTransfer
{
    public class ShowUserDto : IApplicationActor
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
        [Display(Name = "Username")]
        [RegularExpression(@"^[A-z0-9]{3,30}$", ErrorMessage = "Must be at least 3 letters long, and no special characters allowed.")]
        public string Username { get; set; }
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Role")]
        public string RoleName { get; set; }
        public int RoleId { get; set; }
        [Required]
        public string Password { get; set; }
        public List<int> Cases { get; set; }

        public string Identity => Username;

        public IEnumerable<int> AllowedUseCases => Cases;
    }
}
