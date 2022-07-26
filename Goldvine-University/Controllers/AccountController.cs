using Goldvine_University.Models;
using Goldvine_University.Models.ViewModel;
using Goldvine_University.Repositiory.IRepository;
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
            if (!await _roleManager.RoleExistsAsync("Student"))
            {
                await _roleManager.CreateAsync(new IdentityRole("Student"));
            }
            List<SelectListItem> listItems = new List<SelectListItem>();

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
            registerViewModel.ReturnUrl = returnUrl;
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var user = new AppUser
                {
                    Email = registerViewModel.Email,
                    UserName = registerViewModel.Email,
                    FullName = registerViewModel.FullName,
                    Gender = registerViewModel.Gender,
                    DOB = registerViewModel.DOB,
                    RegNumber = registerViewModel.RegNumber,
                    Faculty = registerViewModel.Faculty,
                    Department = registerViewModel.Department,
                };
                var result = await _userManager.CreateAsync(user, registerViewModel.Password);
                if (result.Succeeded)
                {
                    if (registerViewModel.RoleSelected != null && registerViewModel.RoleSelected.Length > 0 && registerViewModel.RoleSelected == "Student")
                    {
                        await _userManager.AddToRoleAsync(user, "Student");
                    }
                    var roles = await _userManager.GetRolesAsync(user);
                    string role = roles.FirstOrDefault();
                    //if (role.Equals("Student"))
                    //{
                    //    return RedirectToAction("StudentProfile", "ProfileDetail");
                    //}
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    //return LocalRedirect(returnUrl);
                    return RedirectToAction("StudentProfile", "ProfileDetail");
                }
                ModelState.AddModelError("Password", "User could not be created. Password not Unique enough.");
            }
            List<SelectListItem> listItems = new List<SelectListItem>();

            listItems.Add(new SelectListItem()
            {
                Value = "Student",
                Text = "Student"
            });
            registerViewModel.RoleList = listItems;
            return View(registerViewModel);
        }



        //ADMIN REGISTER CONTROLLER

        public async Task<IActionResult> AdminRegister(string? returnUrl = null)
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


            AdminViewModel adminViewModel = new AdminViewModel();
            adminViewModel.RoleList = listItems;
            adminViewModel.ReturnUrl = returnUrl;
            return View(adminViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdminRegister(AdminViewModel adminViewModel, string? returnUrl = null)
        {
            adminViewModel.ReturnUrl = returnUrl; ;
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var user = new AppUser
                {
                    Email = adminViewModel.Email,
                    UserName = adminViewModel.Username
                };
                var result = await _userManager.CreateAsync(user, adminViewModel.Password);
                if (result.Succeeded)
                {
                    if (adminViewModel.RoleSelected != null && adminViewModel.RoleSelected.Length > 0 && adminViewModel.RoleSelected == "Admin")
                    {
                        await _userManager.AddToRoleAsync(user, "Admin");
                    }
                    else if (adminViewModel.RoleSelected != null && adminViewModel.RoleSelected.Length > 0 && adminViewModel.RoleSelected == "Lecturer")
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
            adminViewModel.RoleList = listItems;
            return View(adminViewModel);
        }


        //LECTURER REGISTER CONTROLLER
        public async Task<IActionResult> LecturerRegister(string? returnUrl = null)
        {
            if (!await _roleManager.RoleExistsAsync("lecturer"))
            {
                await _roleManager.CreateAsync(new IdentityRole("Lecturer"));
            }
            List<SelectListItem> listItems = new List<SelectListItem>();

            listItems.Add(new SelectListItem()
            {
                Value = "Lecturer",
                Text = "Lecturer"
            });


            LecturerRegisterViewModel lecturerRegisterviewModel = new LecturerRegisterViewModel();
            lecturerRegisterviewModel.RoleList = listItems;
            lecturerRegisterviewModel.ReturnUrl = returnUrl;
            return View(lecturerRegisterviewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LecturerRegister(LecturerRegisterViewModel lecturerRegisterviewModel, string? returnUrl = null)
        {
            lecturerRegisterviewModel.ReturnUrl = returnUrl; ;
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var user = new AppUser
                {
                    Email = lecturerRegisterviewModel.Email,
                    UserName = lecturerRegisterviewModel.Email,
                    FullName = lecturerRegisterviewModel.FullName,
                    //Image = lecturerRegisterviewModel.Image,
                    Gender = lecturerRegisterviewModel.Gender,
                    DOB = lecturerRegisterviewModel.DOB,
                    RegNumber = lecturerRegisterviewModel.RegNumber,
                    Faculty = lecturerRegisterviewModel.Faculty,
                    Department = lecturerRegisterviewModel.Department,
                };
                var result = await _userManager.CreateAsync(user, lecturerRegisterviewModel.Password);
                if (result.Succeeded)
                {
                    if (lecturerRegisterviewModel.RoleSelected != null && lecturerRegisterviewModel.RoleSelected.Length > 0 && lecturerRegisterviewModel.RoleSelected == "Lecturer")
                    {
                        await _userManager.AddToRoleAsync(user, "Lecturer");
                    }
                    var roles = await _userManager.GetRolesAsync(user);
                    string role = roles.FirstOrDefault();
                    //if (role.Equals("Student"))
                    //{
                    //    return RedirectToAction("StudentProfile", "ProfileDetail");
                    //}
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    //return LocalRedirect(returnUrl);
                    return RedirectToAction("LecturerProfile", "ProfileDetail");
                }
                ModelState.AddModelError("Password", "User could not be created. Password not Unique enough.");
            }
            List<SelectListItem> listItems = new List<SelectListItem>();
            listItems.Add(new SelectListItem()
            {
                Value = "Lecturer",
                Text = "Lecturer"
            });
            lecturerRegisterviewModel.RoleList = listItems;
            return View(lecturerRegisterviewModel);
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
            returnUrl ??= Url.Content("~/");

            if (ModelState.IsValid)
            {

                var result = await _signInManager.PasswordSignInAsync(loginViewModel.UserName,
                    loginViewModel.Password,
                    loginViewModel.RememberMe,
                    lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    var user = await _userManager.FindByNameAsync(loginViewModel.UserName);
                    var roles = await _userManager.GetRolesAsync(user);
                    string role = roles.FirstOrDefault();
                    if (role.Equals("Student"))
                    {
                        return RedirectToAction("StudentProfile", "ProfileDetail");
                    }
                    else if (role.Equals("Lecturer"))
                    {
                        return RedirectToAction("LecturerProfile", "ProfileDetail");
                    }
                    //return RedirectToAction("Index", "Home");
                    return LocalRedirect(returnUrl);
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
            return RedirectToAction("Index", "Account");
        }
    }
}
