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
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Display(Name = "Profile Image")]
        public string Image { get; set; }

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

        [NotMapped]
        public string RoleId { get; set; }
        [NotMapped]
        public string Role { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> RoleList { get; set; }

    }
}
