using ForumWebApp.Models;

namespace ForumWebApp.Interfaces
{
    public interface IForumThreadRepository : IRepository<ForumThread, int>
    {
        public Task<IEnumerable<ForumThread>> GetAllThreadsFollowedByUser(string userId);
        public Task<int> GetAllThreadsCountFollowedByUser(string userId);
        public Task<ForumThreadUserFollow> GetFollowThreadByUser(int threadId, string userId);
        public bool AddFollowForThreadByUser(ForumThreadUserFollow userThreadFollow);
        public bool DeleteFollowForThreadByUser(ForumThreadUserFollow userThreadFollow);
    }
}
