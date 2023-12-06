using ForumWebApp.Models;

namespace ForumWebApp.Interfaces
{
    public interface IUserRepository : IRepository<AppUser, string>
    {
        Task<AppUser> GetUserByUsernameAsync(string username);
        public Task<IEnumerable<AppUser>> GetAllFollowersOfForumThread(int threadId);
        public Task<int> GetAllFollowersCountOfForumThread(int threadId);
    }
}
