using ForumWebApp.Models;
using ForumWebApp.Interfaces;
using ForumWebApp.Data;

namespace ForumWebApp.Interfaces
{
    public interface IThreadPostRepository : IRepository<ThreadPost, int>
    {
        Task<IEnumerable<ThreadPost>> GetPostsByThreadIdAsync(int threadId);
        Task<IEnumerable<ThreadPost>> GetAllPostsFromThreadsFollowedByUserWithinTimePeriod(string userId, TimeSpan start, TimeSpan end);
    }
}
