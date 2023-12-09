using ForumWebApp.Extensions;
using ForumWebApp.Interfaces;
using ForumWebApp.Models;
using ForumWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity.Core.Mapping;
using System.Runtime.CompilerServices;

namespace ForumWebApp.Controllers
{
    public class ForumThreadController : Controller
    {
        private readonly IForumThreadRepository _forumThreadRepository;
        private readonly IUserRepository _userRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ForumThreadController(IForumThreadRepository forumThreadRepository,IUserRepository userRepository, IHttpContextAccessor httpContextAccessor)
        {
            _forumThreadRepository = forumThreadRepository;
            _httpContextAccessor = httpContextAccessor;
            _userRepository = userRepository;
        }
        public async Task<IActionResult> Index()
        {
            var threads = await _forumThreadRepository.GetAllAsync();
            return View(threads);
        }
        public async Task<IActionResult> Detail(int id)
        {
            var thread = await _forumThreadRepository.GetByIdAsync(id);

            var sortedPosts = thread.Posts.OrderByDescending(p => p.CreateAtUtc).ToList();
            var numberOfFollowers = await _userRepository.GetAllFollowersCountOfForumThread(id);
            var currentUserId = _httpContextAccessor?.HttpContext?.User?.GetUserId();
            var isFollowing = (currentUserId != null) ? await _forumThreadRepository.GetFollowThreadByUser(id, currentUserId) != null : false;

            var viewModelThread = new ThreadDetailViewModel
            {
                Id = thread.Id,
                Title = thread.Title,
                Description = thread.Description,
                Posts = sortedPosts,
                NumberOfFollowers = numberOfFollowers,
                IsFollowing = isFollowing,
                IsUserLoggedIn = User.Identity.IsAuthenticated

            };
            return View(viewModelThread);
        }
        [HttpPost]
        public async Task<IActionResult> Follow(int threadId)
        {
            var currentUseId = _httpContextAccessor?.HttpContext?.User?.GetUserId();
            if(currentUseId==null)
            {
                return BadRequest("User not logged in!");
            }

            var follow = await _forumThreadRepository.GetFollowThreadByUser(threadId, currentUseId);
            if(follow != null)
            {
                return BadRequest("User is following the thread!");
            }

            var newFollow = new ForumThreadUserFollow
            {
                UserId = currentUseId,
                ForumThreadId = threadId
            };

            var result = _forumThreadRepository.AddFollowForThreadByUser(newFollow);
            if(!result)
            {
                return Json("False");
            }
            return Json("True");
        }
        [HttpPost]
        public async Task<IActionResult> Unfollow(int threadId)
        {
            var currentUserId = _httpContextAccessor?.HttpContext?.User?.GetUserId();
            if (currentUserId == null)
            {
                return BadRequest("User not logged in!");
            }

            var follow = await _forumThreadRepository.GetFollowThreadByUser(threadId, currentUserId);
            if (follow == null)
            {
                return BadRequest("User is not following the thread!");
            }
            var result = _forumThreadRepository.DeleteFollowForThreadByUser(follow);
            if (!result)
            {
                return Json("False");
            }
            
            return Json("True");
        }
    }
}
