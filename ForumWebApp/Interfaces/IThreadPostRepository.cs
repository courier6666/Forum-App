using ForumWebApp.Models;
using ForumWebApp.Interfaces;

namespace ForumWebApp.Interfaces
{
    public interface IThreadPostRepository : IRepository<ThreadPost, int>
    {
        Task<IEnumerable<ThreadPost>> GetPostsByThreadIdAsync(int threadId);
    }
}
