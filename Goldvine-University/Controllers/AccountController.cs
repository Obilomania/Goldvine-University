using Goldvine_University.Models.ViewModel;
using IdentityFrameWork.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IdentityFrameWork.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        //REGISTER CONTROLLER
        public async Task<IActionResult> Register(string? returnUrl = null)
        {
            if (!await _roleManager.RoleExistsAsync("Admin"))
            {
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
                await _roleManager.CreateAsync(new IdentityRole("Lecturer"));
                await _roleManager.CreateAsync(new IdentityRole("Student"));
            }
            List<SelectListItem> listItems = new List<SelectListItem>();
            listItems.Add(new SelectListItem()
            {
                Value = "Admin",
                Text = "Admin"
            }); 
            listItems.Add(new SelectListItem()
            {
                Value = "Lecturer",
                Text = "Lecturer"
            });
            listItems.Add(new SelectListItem()
            {
                Value = "Student",
                Text = "Student"
            });


            RegisterViewModel registerviewModel = new RegisterViewModel();
            registerviewModel.RoleList = listItems;
            registerviewModel.ReturnUrl = returnUrl;
            return View(registerviewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel, string? returnUrl = null)
        {
            registerViewModel.ReturnUrl = returnUrl; ;
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var user = new AppUser
                {
                    Email = registerViewModel.Email,
                    UserName = registerViewModel.Username
                };
                var result = await _userManager.CreateAsync(user, registerViewModel.Password);
                if (result.Succeeded)
                {
                    if (registerViewModel.RoleSelected != null && registerViewModel.RoleSelected.Length > 0 && registerViewModel.RoleSelected == "Admin")
                    {
                        await _userManager.AddToRoleAsync(user, "Admin");
                    }
                    else if (registerViewModel.RoleSelected != null && registerViewModel.RoleSelected.Length > 0 && registerViewModel.RoleSelected == "Lecturer")
                    {
                        await _userManager.AddToRoleAsync(user, "Lecturer");
                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(user, "Student");
                    }
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
                ModelState.AddModelError("Password", "User could not be created. Password not Unique enough.");
            }
            List<SelectListItem> listItems = new List<SelectListItem>();
            listItems.Add(new SelectListItem()
            {
                Value = "Admin",
                Text = "Admin"
            });
            listItems.Add(new SelectListItem()
            {
                Value = "Lecturer",
                Text = "Lecturer"
            });
            listItems.Add(new SelectListItem()
            {
                Value = "Student",
                Text = "Student"
            });
            registerViewModel.RoleList = listItems;
            return View(registerViewModel);
        }



        //[HttpGet]
        //public IActionResult ForgotPassword()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult ForgotPassword()
        //{

        //}



        [HttpGet]
        public IActionResult Login(string? returnUrl = null)
        {
            LoginViewModel loginViewModel = new LoginViewModel();
            loginViewModel.ReturnUrl = returnUrl ?? Url.Content("~/");
            return View(loginViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel, string? returnUrl)
        {
            if (ModelState.IsValid)
            {

                var result = await _signInManager.PasswordSignInAsync(loginViewModel.UserName,
                    loginViewModel.Password,
                    loginViewModel.RememberMe,
                    lockoutOnFailure: true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                if (result.IsLockedOut)
                {
                    return View("LockOut");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt");
                    return View(loginViewModel);
                }
            }
            return View(loginViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOff()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
