using Goldvine_University.Data.Enum;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityFrameWork.Models
{
    public class AppUser : IdentityUser
    {
        [Required]
        [Display(Name = "Username")]
        public string FullName { get; set; }

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

        [Required]
        public string BodyBuild { get; set; }

        [Required]
        public string Age { get; set; }


        [NotMapped]
        public string RoleId { get; set; }
        [NotMapped]
        public string Role { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> RoleList { get; set; }

    }
}
