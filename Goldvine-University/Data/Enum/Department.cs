using System.ComponentModel.DataAnnotations;

namespace Goldvine_University.Data.Enum
{
    public enum Department
    {
        Accounting,
        [Display(Name = "Banking and Finance")]
        BankingAndFinance,
        Economics,
        Lawyer,
        Architecture,
        Fashion,
        Engineering,
        Teacher
    }
}
