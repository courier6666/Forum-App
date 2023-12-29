using ForumWebApp.Data;
using ForumWebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ForumWebApp.ViewModels;

namespace ForumWebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginUserViewModel loginUserViewModel)
        {
            if(!ModelState.IsValid)
            {
                return View(loginUserViewModel);
            }
            
            var user = await _userManager.FindByEmailAsync(loginUserViewModel.Email);
            if(user == null)
            {
                TempData["Error"] = "Wrong credentials. Please, try again";
                return View(loginUserViewModel);
            }

            var passwordCheck = await _userManager.CheckPasswordAsync(user, loginUserViewModel.Password);
            if(!passwordCheck)
            {
                TempData["Error"] = "Wrong credentials. Please, try again";
                return View(loginUserViewModel);
            }

            var result = await _signInManager.PasswordSignInAsync(user, loginUserViewModel.Password, false, false);
            if (!result.Succeeded)
            {
                TempData["Error"] = "Wrong credentials. Please, try again";
                return View(loginUserViewModel);
            }

            return RedirectToAction("Index", "ForumThread");
        }
        public async Task<IActionResult> Register()
        {
            var user = new RegisterUserViewModel();
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserViewModel registerUserViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(registerUserViewModel);
            }

            var user = await _userManager.FindByEmailAsync(registerUserViewModel.Email);
            if (user != null)
            {
                TempData["Error"] = "This email address is already in use";
                return View(registerUserViewModel);
            }

            var newUser = new AppUser
            {
                Email = registerUserViewModel.Email,
                UserName = registerUserViewModel.Email
            };
            var newUserResponse = await _userManager.CreateAsync(newUser, registerUserViewModel.Password);

            string errorMessage = "";

            if (newUserResponse.Errors.Any())
            {
                foreach (var error in newUserResponse.Errors)
                {
                    errorMessage += error.Description + '\n';
                }
                TempData["Error"] = errorMessage;
                return View(registerUserViewModel);
            }
            

            if (newUserResponse.Succeeded)
                await _userManager.AddToRoleAsync(newUser, "user");

            return RedirectToAction("Login");
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "ForumThread");
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
