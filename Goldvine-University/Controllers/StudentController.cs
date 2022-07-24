using Microsoft.AspNetCore.Mvc;

namespace Goldvine_University.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
