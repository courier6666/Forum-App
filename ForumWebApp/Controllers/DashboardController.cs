using Microsoft.AspNetCore.Mvc;
using ForumWebApp.ViewModels;
using ForumWebApp.Extensions;
using Microsoft.AspNet.Identity;
using ForumWebApp.Interfaces;

namespace ForumWebApp.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserRepository _userRepository;
        public DashboardController(IHttpContextAccessor httpContextAccessor, IUserRepository userRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _userRepository = userRepository;
        }
        public async Task<IActionResult> Index()
        {
            var user = await _userRepository.GetByIdAsync(_httpContextAccessor.HttpContext?.User.GetUserId());
            return View(user);
        }
        public async Task<IActionResult> EditUserProfile()
        {
            var currentUserId = _httpContextAccessor.HttpContext?.User.GetUserId();
            var user = await _userRepository.GetByIdAsync(currentUserId);

            if (user == null)
                return View("Error");

            var userViewModel = new EditUserDashboardViewModel
            {
                Id = currentUserId,
                UserName = user.UserName
            };

            return View(userViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> EditUserProfile(EditUserDashboardViewModel editUserViewModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit profile");
                return View("EditUserProfile", editUserViewModel);
            }

            var userByName = await _userRepository.GetUserByUsernameAsync(editUserViewModel.UserName);
            var currentUserId = _httpContextAccessor.HttpContext?.User.GetUserId();
            var userLoggedIn = await _userRepository.GetByIdAsync(currentUserId);

            if (userByName != userLoggedIn)
            {
                ModelState.AddModelError("", "There is a user with such username!");
                return View(editUserViewModel);
            }

            var user = await _userRepository.GetByIdAsync(editUserViewModel.Id);

            if(user==null)
            {
                ModelState.AddModelError("", "Error! User not found!");
                return View(editUserViewModel);
            }

            user.UserName = editUserViewModel.UserName;

            _userRepository.Update(user);

            return View("Index", user);
        }
    }
}
