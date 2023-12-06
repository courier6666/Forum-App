using ForumWebApp.Interfaces;
using ForumWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ForumWebApp.Controllers
{
    public class ForumThreadController : Controller
    {
        private readonly IForumThreadRepository _forumThreadRepository;
        public ForumThreadController(IForumThreadRepository forumThreadRepository)
        {
            _forumThreadRepository = forumThreadRepository;
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
            var numberOfFollowers = 

            var viewModelThread = new ThreadDetailViewModel
            {
                Id = thread.Id,
                Title = thread.Title,
                Description = thread.Description,
                Posts = sortedPosts
                

            };
            return View(viewModelThread);
        }
    }
}
