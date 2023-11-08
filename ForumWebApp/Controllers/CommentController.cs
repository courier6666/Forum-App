using ForumWebApp.Interfaces;
using ForumWebApp.Models;
using ForumWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using ForumWebApp.Extensions;
using static ForumWebApp.Extensions.JsonExtension;

namespace ForumWebApp.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IUserRepository _userRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CommentController(ICommentRepository commentRepository, IUserRepository userRepository, IHttpContextAccessor httpContextAccessor) 
        { 
            _commentRepository = commentRepository;
            _httpContextAccessor = httpContextAccessor;
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddComment(CreatedCommentViewModel createdCommentViewModel, int postId)
        {
            if(_httpContextAccessor.HttpContext?.User.GetUserId() == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var commentAuthor = await _userRepository.GetByIdAsync(_httpContextAccessor.HttpContext.User.GetUserId());
            if(commentAuthor == null)
            {
                return BadRequest("Author has not been found!");
            }
            var comment = new Comment
            {
                AuthorId = _httpContextAccessor.HttpContext.User.GetUserId(),
                Author = commentAuthor,
                Content = createdCommentViewModel.Content,
                CreateAtUtc = DateTime.UtcNow
            };

            if (createdCommentViewModel.ParentCommentId != null)
                comment.ParentCommentId = createdCommentViewModel.ParentCommentId;
            else
                comment.PostId = postId;

            if(!_commentRepository.Add(comment))
            {
                return BadRequest("Failed to save comment!");
            }

            return Json(CommentToJson(comment));
        }
        [HttpPost]
        public async Task<IActionResult> DeleteComment(int commentId)
        {
            var comment = await _commentRepository.GetByIdNoTracking(commentId);
            if(comment == null)
            {
                return BadRequest("No comment with such id!");
            }

            var deleteResult = _commentRepository.Delete(comment);
            if(!deleteResult)
            {
                return BadRequest("Failed to delete comment!");
            }
            return Json("Success");
        }
    }
}
