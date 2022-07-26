using Goldvine_University.Data.Enum;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Goldvine_University.Models
{
    public class Photo 
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Profile Image")]
        public string? Image { get; set; }

    }
}
