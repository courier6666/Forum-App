
using ForumWebApp.Models;
using System.Collections.Generic;

namespace ForumWebApp.Interfaces
{
    public interface ICommentRepository : IRepository<Comment, int>
    {
        Task<IEnumerable<Comment>> GetAllCommentsByPostId(int postId);
        Task<Comment> GetByIdNoTracking(int commentId);
    }
}
