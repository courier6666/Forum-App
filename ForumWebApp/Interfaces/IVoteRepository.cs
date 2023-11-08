using ForumWebApp.Data.Enums;
using ForumWebApp.Models;

namespace ForumWebApp.Interfaces
{
    public interface IVoteRepository : IRepository<Vote, int>
    {
        Task<ICollection<Vote>> GetAllPostVotesOfType(int postId, VoteType voteType);
        Task<ICollection<Vote>> GetAllCommentVotesOfType(int commentId, VoteType voteType);
        Task<Vote> GetVoteByUserAndPost(string userId, int postId);
        Task<Vote> GetVoteByUserAndComment(string userId, int commentId);
    }
}
