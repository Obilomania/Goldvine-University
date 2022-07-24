using Goldvine_University.Data.Enum;
using System.ComponentModel.DataAnnotations;

namespace Goldvine_University.Models.ViewModel
{
    public class ProfileViewModel
    {
        public string  Id { get; set; }
        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Display(Name = "Profile Photo")]
        public string Image { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        public Gender Gender { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date Of Birth")]
        public DateTime DOB { get; set; }

        [Required]
        [Display(Name = "Registration Number")]
        public string RegNumber { get; set; }

        public Faculty Faculty { get; set; }
        public Department Department { get; set; }
    }
}
