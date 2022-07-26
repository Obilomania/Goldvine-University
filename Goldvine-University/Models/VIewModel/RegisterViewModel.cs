using Goldvine_University.Data.Enum;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Goldvine_University.Models.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Display(Name = "Profile Image")]
        public string Photo { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        [Required]
        [Display(Name = "Registration No.")]
        public string RegNumber { get; set; }

        [Required]
        public Faculty Faculty { get; set; }

        [Required]
        public Department Department { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = " The {0} must be atleast {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "The Passowrd and confirmation password does not match.")]
        public string ConfirmPassword { get; set; }

        public string? ReturnUrl { get; set; }
        public IEnumerable<SelectListItem>? RoleList { get; set; }
        public string? RoleSelected { get; set; }

    }
}