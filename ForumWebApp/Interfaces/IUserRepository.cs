using ForumWebApp.Models;

namespace ForumWebApp.Interfaces
{
    public interface IUserRepository : IRepository<AppUser, string>
    {
        Task<AppUser> GetUserByUsernameAsync(string username);
    }
}
