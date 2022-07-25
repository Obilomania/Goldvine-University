using Goldvine_University.Models.ViewModel;
using IdentityFrameWork.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Goldvine_University.Controllers
{
    public class ProfileDetailController : Controller
    {

        private UserManager<AppUser> _userManager;

        public ProfileDetailController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IActionResult> StudentProfile()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            var registerVIewModel = new RegisterViewModel()
            {
                FullName = user.FullName,
                BodyBuild = user.BodyBuild,
                Age = user.Age,
            };
            return View(registerVIewModel); ;
        }
    }
}
