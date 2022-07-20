using System.ComponentModel.DataAnnotations;

namespace Goldvine_University.Models.ViewModel
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
