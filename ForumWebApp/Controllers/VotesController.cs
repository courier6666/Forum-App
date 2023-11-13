using ForumWebApp.Data.Enums;
using ForumWebApp.Extensions;
using ForumWebApp.Interfaces;
using ForumWebApp.Models;
using ForumWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;

namespace ForumWebApp.Controllers
{
    public class VotesController : Controller
    {
        private readonly IVoteRepository _voteRepository;
        private readonly IUserRepository _userRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public VotesController(IVoteRepository voteRepository, IUserRepository userRepository, IHttpContextAccessor httpContextAccessor)
        {
            _voteRepository = voteRepository;
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddVote(VoteAddedViewModel voteAddedViewModel)
        {
            if (_httpContextAccessor.HttpContext?.User.GetUserId() == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var voteAuthor = await _userRepository.GetByIdAsync(_httpContextAccessor.HttpContext.User.GetUserId());

            if (voteAddedViewModel.PostId != null)
            {
                var existingVote = await _voteRepository.GetVoteByUserAndPost(voteAuthor.Id, (int)(voteAddedViewModel.PostId));
                if (existingVote != null)
                {
                    existingVote.VoteType = voteAddedViewModel.VoteType;
                    if (!_voteRepository.Update(existingVote))
                        return BadRequest("Failed to update vote for post!");
                }
                else
                {
                    var newVote = new Vote
                    {
                        AuthorId = _httpContextAccessor.HttpContext.User.GetUserId(),
                        PostId = voteAddedViewModel.PostId,
                        CreateAtUtc = DateTime.UtcNow,
                        VoteType = voteAddedViewModel.VoteType
                    };
                    if (!_voteRepository.Add(newVote))
                        return BadRequest("Failed to add vote for post!");
                }
                var allUpvotes = await _voteRepository.GetAllPostVotesOfType((int)voteAddedViewModel.PostId, VoteType.UpVote);
                var allDownvotes = await _voteRepository.GetAllPostVotesOfType((int)voteAddedViewModel.PostId, VoteType.DownVote);

                var countUpvotes = (allUpvotes == null) ? 0 : allUpvotes.Count();
                var countDownvotes = (allDownvotes == null) ? 0 : allDownvotes.Count();

                return Json("{" + $"\"countUpvotes\": \"{countUpvotes}\", \"countDownvotes\": \"{countDownvotes}\"" + "}");
            }
            else if (voteAddedViewModel.CommentId != null)
            {
                var existingVote = await _voteRepository.GetVoteByUserAndComment(voteAuthor.Id, (int)(voteAddedViewModel.CommentId));
                if (existingVote != null)
                {
                    existingVote.VoteType = voteAddedViewModel.VoteType;
                    if (!_voteRepository.Update(existingVote))
                        return BadRequest("Failed to update vote for comment!");
                }
                else
                {
                    var newVote = new Vote
                    {
                        AuthorId = _httpContextAccessor.HttpContext.User.GetUserId(),
                        CommentId = voteAddedViewModel.CommentId,
                        CreateAtUtc = DateTime.UtcNow,
                        VoteType = voteAddedViewModel.VoteType
                    };
                    if (!_voteRepository.Add(newVote))
                        return BadRequest("Failed to add vote for comment!");
                }
                var allUpvotes = await _voteRepository.GetAllCommentVotesOfType((int)voteAddedViewModel.CommentId, VoteType.UpVote);
                var allDownvotes = await _voteRepository.GetAllCommentVotesOfType((int)voteAddedViewModel.CommentId, VoteType.DownVote);

                var countUpvotes = (allUpvotes == null) ? 0 : allUpvotes.Count();
                var countDownvotes = (allDownvotes == null) ? 0 : allDownvotes.Count();

                return Json("{" + $"\"countUpvotes\": \"{countUpvotes}\", \"countDownvotes\": \"{countDownvotes}\"" + "}");
            }

            return BadRequest("Failed to add vote!No comment or post id!");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteVoteById(int voteId)
        {
            var vote = await _voteRepository.GetByIdAsync(voteId);
            if (vote == null)
            {
                return BadRequest("No vote with such id!");
            }

            if (!_voteRepository.Delete(vote))
            {
                return BadRequest("Failed to delete vote!");
            }
            return Json("Success");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteVote(VoteDeletedViewModel voteDeletedViewModel)
        {
            if(voteDeletedViewModel.PostId!=null)
            {
                var vote = await _voteRepository.GetVoteByUserAndPost(_httpContextAccessor?.HttpContext?.User?.GetUserId(), (int)voteDeletedViewModel.PostId);
                if (vote != null) {
                    _voteRepository.Delete(vote);
                    var allUpvotes = await _voteRepository.GetAllCommentVotesOfType((int)voteDeletedViewModel.PostId, VoteType.UpVote);
                    var allDownvotes = await _voteRepository.GetAllCommentVotesOfType((int)voteDeletedViewModel.PostId, VoteType.DownVote);

                    var countUpvotes = (allUpvotes == null) ? 0 : allUpvotes.Count();
                    var countDownvotes = (allDownvotes == null) ? 0 : allDownvotes.Count();
                    return Json("{" + $"\"countUpvotes\": \"{countUpvotes}\", \"countDownvotes\": \"{countDownvotes}\"" + "}");
                }
                return BadRequest("No such vote to delete!");
            }
            else if(voteDeletedViewModel.CommentId!=null)
            {
                var vote = await _voteRepository.GetVoteByUserAndComment(_httpContextAccessor?.HttpContext?.User?.GetUserId(), (int)voteDeletedViewModel.CommentId);
                if (vote != null)
                {
                    _voteRepository.Delete(vote);
                    var allUpvotes = await _voteRepository.GetAllCommentVotesOfType((int)voteDeletedViewModel.CommentId, VoteType.UpVote);
                    var allDownvotes = await _voteRepository.GetAllCommentVotesOfType((int)voteDeletedViewModel.CommentId, VoteType.DownVote);

                    var countUpvotes = (allUpvotes == null) ? 0 : allUpvotes.Count();
                    var countDownvotes = (allDownvotes == null) ? 0 : allDownvotes.Count();
                    return Json("{" + $"\"countUpvotes\": \"{countUpvotes}\", \"countDownvotes\": \"{countDownvotes}\"" + "}");
                }
                return BadRequest("No such vote to delete!");
            }
            return BadRequest("Failed to delete vote!No comment or post id!");
        }
        [HttpPost]
        public async Task<IActionResult> CheckCommentVoted(int commentId, VoteType voteType)
        {
            var vote = await _voteRepository.GetVoteByUserAndComment(_httpContextAccessor?.HttpContext?.User?.GetUserId(), commentId);
            if(vote == null)
            {
                return Json(false);
            }
            return Json(vote.VoteType == voteType);
        }
        [HttpPost]
        public async Task<IActionResult> CheckPostVoted(int postId, VoteType voteType)
        {
            var vote = await _voteRepository.GetVoteByUserAndPost(_httpContextAccessor?.HttpContext?.User?.GetUserId(), postId);
            if (vote == null)
            {
                return Json(false);
            }
            return Json(vote.VoteType == voteType);
        }
        [HttpPost]
        public async Task<IActionResult> GetVoteTypeOfVoteOfUserForPost(int postId)
        {
            var vote = await _voteRepository.GetVoteByUserAndPost(_httpContextAccessor?.HttpContext?.User?.GetUserId(), postId);
            if(vote==null)
            {
                return BadRequest("No vote of current user for post with such id!");
            }
            return Json('{' + $"\"voteType\": {(int)vote.VoteType}" + '}');
        }
        [HttpPost]
        public async Task<IActionResult> GetVoteTypeOfVoteOfUserForComment(int commentId)
        {
            var vote = await _voteRepository.GetVoteByUserAndComment(_httpContextAccessor?.HttpContext?.User?.GetUserId(), commentId);
            if (vote == null)
            {
                return BadRequest("No vote of current user for comment with such id!");
            }
            return Json('{' + $"\"voteType\": {(int)vote.VoteType}" + '}');
        }
    }
}
