using System.ComponentModel.DataAnnotations;

namespace Goldvine_University.Data.Enum
{
    public enum Faculty
    {
        FACULTY,
        Science,
        Law,
        fArt,
        [Display(Name = "Social Science")]
        FacultyOfSocialScience
    }
}
