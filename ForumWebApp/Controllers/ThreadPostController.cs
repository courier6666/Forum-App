using ForumWebApp.Interfaces;
using ForumWebApp.Models;
using ForumWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore;
using ForumWebApp.Extensions;
using ForumWebApp.Data.Enums;

namespace ForumWebApp.Controllers
{
    public class ThreadPostController : Controller
    {
        private readonly IThreadPostRepository _threadPostRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ThreadPostController(IThreadPostRepository threadPostRepository, IHttpContextAccessor httpContextAccessor)
        {
            _threadPostRepository = threadPostRepository;
            _httpContextAccessor = httpContextAccessor;

        }
        public async Task<IActionResult> Index(int threadId)
        {
            var posts = await _threadPostRepository.GetPostsByThreadIdAsync(threadId);
            return View(posts);
        }
        public async Task<IActionResult> RecentPosts()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login","Account");
            }
            var userId = _httpContextAccessor.HttpContext?.User?.GetUserId();

            var postsByEachTimePeriod = new List<(string, ICollection<ThreadPost>)>();
            var tuple = (WithinTimePeriod.GetTimePeriodNameById(0), 
                (await _threadPostRepository.GetAllPostsFromThreadsFollowedByUserWithinTimePeriod(userId, new TimeSpan(0), WithinTimePeriod.Day)).
                ToList());
            
            postsByEachTimePeriod.Add(tuple);

            for(int i = 1;i < WithinTimePeriod.PeriodsCount;++i)
            {
                tuple = (WithinTimePeriod.GetTimePeriodNameById(i),
                (await _threadPostRepository.GetAllPostsFromThreadsFollowedByUserWithinTimePeriod(userId, WithinTimePeriod.GetTimePeriodById(i - 1), WithinTimePeriod.GetTimePeriodById(i))).
                ToList());
                postsByEachTimePeriod.Add(tuple);
            }

            var recentPostsViewModel = new RecentPostsViewModel
            {
                RecentPostsByEachPeriod = postsByEachTimePeriod
            };
            return View(recentPostsViewModel);
        }
        [HttpPost]

        public async Task<IActionResult> Detail(int threadId, int postId)
        {
            var post = await _threadPostRepository.GetByIdAsync(postId);

            if(post == null)
            {
                return NotFound("Post not found!");
            }

            if(post.ThreadId != threadId)
            {
                return View("Error");
            }

            var postViewModel = new PostDetailViewModel
            {
                Post = post,
                HttpContextAccessor = _httpContextAccessor
            };

            return View(postViewModel);
        }
        public async Task<IActionResult> Create(int threadId)
        {
            var currentUserId = _httpContextAccessor.HttpContext?.User.GetUserId();

            if(currentUserId == null)
            {
                return RedirectToAction("Login","Account");
            }

            var post = new CreatedPostViewModel
            {
                ThreadId = threadId,
                AuthorId = currentUserId
            };

            return View(post);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreatedPostViewModel createdPostViewModel)
        {
            
            if (!ModelState.IsValid)
            {
                return View(createdPostViewModel);
            }

            var post = new ThreadPost
            {
                AuthorId = createdPostViewModel.AuthorId,
                Title = createdPostViewModel.Title,
                Content = createdPostViewModel.Content,
                ThreadId = createdPostViewModel.ThreadId,
                CreateAtUtc = DateTime.UtcNow
            };

            if(!_threadPostRepository.Add(post))
                return View(createdPostViewModel);

            return RedirectToAction("Detail", "ForumThread", new {id = createdPostViewModel.ThreadId});
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int postId)
        {
            var post = await _threadPostRepository.GetByIdAsync(postId);
            if(post == null)
            {
                return BadRequest("Post not found!");
            }
            _threadPostRepository.Delete(post);
            return Json("Post has been deleted!");
        }
    }
}
