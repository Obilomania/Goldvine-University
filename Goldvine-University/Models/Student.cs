using Goldvine_University.Data.Enum;
using IdentityFrameWork.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Goldvine_University.Models
{
    public class Student 
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [ValidateNever]
        [Display(Name = "Profile Image")]
        public string? Image { get; set; }

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

        [ForeignKey("AppUser")]
        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
    }
}
