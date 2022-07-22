using Microsoft.AspNetCore.Mvc;

namespace Goldvine_University.Controllers
{
    public class PostController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
