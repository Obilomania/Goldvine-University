using System.ComponentModel.DataAnnotations;

namespace Goldvine_University.Models.VIewModel
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
