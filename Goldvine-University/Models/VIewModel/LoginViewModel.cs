﻿using System.ComponentModel.DataAnnotations;

namespace Goldvine_University.Models.ViewModel
{
    public class LoginViewModel
    {
        //[Required]
        //[EmailAddress]
        //public string Email { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
        public string? ReturnUrl { get; set; }
    }
}
