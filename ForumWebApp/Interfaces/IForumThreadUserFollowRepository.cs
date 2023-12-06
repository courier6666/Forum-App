using ForumWebApp.Models;

namespace ForumWebApp.Interfaces
{
    public interface IForumThreadUserFollowRepository : IRepository<ForumThreadUserFollow>
    {
        public Task<IEnumerable<AppUser>> GetAllFollowersOfForumThread(int threadId);
        public Task<int> GetAllFollowersCountOfForumThread(int threadId);
        public Task<IEnumerable<ForumThread>> GetAllThreadsFollowedByUser(string userId);
        public Task<int> GetAllThreadsCountFollowedByUser(string userId);
    }
}
