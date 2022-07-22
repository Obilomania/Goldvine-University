using System.ComponentModel.DataAnnotations;

namespace Goldvine_University.Data.Enum
{
    public enum Faculty
    {
        [Display(Name ="Faculty Of Science")]
        FacultyOfScience,
        [Display(Name = "Faculty Of Law")]
        FacultyOfLaw,
        [Display(Name = "Faculty Of Art")]
        FacultyOfArt,
        [Display(Name = "Faculty Of Social Science")]
        FacultyOfSocialScience
    }
}
