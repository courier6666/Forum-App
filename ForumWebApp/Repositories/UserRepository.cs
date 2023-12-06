using ForumWebApp.Data;
using ForumWebApp.Interfaces;
using ForumWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ForumWebApp.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(AppUser entity)
        {
            _context.Add(entity);
            return Save();
        }

        public bool Delete(AppUser entity)
        {
            _context.Remove(entity);
            return Save();
        }

        public async Task<IEnumerable<AppUser>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<int> GetAllFollowersCountOfForumThread(int threadId)
        {
            var follows = await _context.ForumThreadUserFollows.Where(f => f.ForumThreadId == threadId).Select(f => f.UserId).ToListAsync();
            return (follows != null) ? follows.Count() : 0;
        }

        public async Task<IEnumerable<AppUser>> GetAllFollowersOfForumThread(int threadId)
        {
            var follows = await _context.ForumThreadUserFollows.Where(f => f.ForumThreadId == threadId).Select(f => f.UserId).ToListAsync();
            var users = await _context.Users.Where(u => follows.Contains(u.Id)).ToListAsync();
            return users;
        }

        public async Task<AppUser> GetByIdAsync(string id)
        {
            return await _context.Users.Include(u=>u.Posts).Include(u=>u.Votes).FirstOrDefaultAsync(u=> u.Id == id);
        }

        public async Task<AppUser> GetUserByUsernameAsync(string username)
        {
            return await _context.Users.Include(u => u.Posts).Include(u => u.Votes).FirstOrDefaultAsync(u => u.UserName == username);
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

        public bool Update(AppUser entity)
        {
            _context.Update(entity);
            return Save();
        }
    }
}
