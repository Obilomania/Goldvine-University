using Microsoft.AspNetCore.Mvc;

namespace Goldvine_University.Controllers
{
    public class AppUserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
