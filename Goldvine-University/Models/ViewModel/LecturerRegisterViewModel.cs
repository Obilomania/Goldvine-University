﻿using Goldvine_University.Data.Enum;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Goldvine_University.Models.ViewModel
{
    public class LecturerRegisterViewModel
    {
        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }


        [Required]
        [Display(Name = "Full Name")]
        public string FUllName { get; set; }

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

        public Gender Gender { get; set; }

        [Required]
        [Display(Name = "Lecturer ID. Number")]
        public string RegNumber { get; set; }

        public Faculty Faculty { get; set; }
        public Department Department { get; set; }

        public string? ReturnUrl { get; set; }
        public IEnumerable<SelectListItem>? RoleList { get; set; }
        public string? RoleSelected { get; set; }
    }
}