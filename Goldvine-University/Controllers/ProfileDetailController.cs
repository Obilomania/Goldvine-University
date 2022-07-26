using Goldvine_University.Models;
using Goldvine_University.Models.ViewModel;
using Goldvine_University.Repositiory.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Goldvine_University.Controllers
{
    public class ProfileDetailController : Controller
    {

        private UserManager<AppUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;

        public ProfileDetailController(UserManager<AppUser> userManager, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }

        //STUDENT PROFILE CONTROLLER
        public async Task<IActionResult> StudentProfile()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            var registerViewModel = new RegisterViewModel()
            {
                FullName = user.FullName,
                Email = user.Email,
                //Image = user.Image,
                Photo = user.Photo,
                Gender = user.Gender,
                DOB = user.DOB,
                Department = user.Department,
                RegNumber = user.RegNumber,
                Faculty = user.Faculty
            };
            return View(registerViewModel); 
        }


        //LECTURER PROFILE CONTROLLER
        public async Task<IActionResult> LecturerProfile()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            var lecturerRegisterViewModel = new LecturerRegisterViewModel()
            {
                FullName = user.FullName,
                Email = user.Email,
                //Image = user.Image,
                Gender = user.Gender,
                DOB = user.DOB,
                Department = user.Department,
                RegNumber = user.RegNumber,
                Faculty = user.Faculty
            };
            return View(lecturerRegisterViewModel);
        }
    }
}
