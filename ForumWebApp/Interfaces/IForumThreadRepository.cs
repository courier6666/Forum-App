using ForumWebApp.Models;

namespace ForumWebApp.Interfaces
{
    public interface IForumThreadRepository : IRepository<ForumThread, int>
    {
        public Task<IEnumerable<ForumThread>> GetAllThreadsFollowedByUser(string userId);
        public Task<int> GetAllThreadsCountFollowedByUser(string userId);
        public Task<bool> IsThreadFollowedByUser(int threadId, string userId);
    }
}
