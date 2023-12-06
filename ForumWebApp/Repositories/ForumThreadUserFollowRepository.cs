using ForumWebApp.Data;
using ForumWebApp.Interfaces;
using ForumWebApp.Models;
using System.Data.Entity;
using System.Threading;

namespace ForumWebApp.Repositories
{
    public class ForumThreadUserFollowRepository : IForumThreadUserFollowRepository
    {
        private readonly ApplicationDbContext _context;
        public ForumThreadUserFollowRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(ForumThreadUserFollow entity)
        {
            _context.Add(entity);
            return Save();
        }

        public bool Delete(ForumThreadUserFollow entity)
        {
            _context.Remove(entity);
            return Save();
        }

        public async Task<IEnumerable<ForumThreadUserFollow>> GetAllAsync()
        {
            return await _context.ForumThreadUserFollows.ToListAsync();
        }

        public async Task<int> GetAllFollowersCountOfForumThread(int threadId)
        {
            var follows = await _context.ForumThreadUserFollows.Where(f => f.ForumThreadId == threadId).Select(f => f.UserId).ToListAsync();
            return (follows!=null) ? follows.Count() : 0;
        }

        public async Task<IEnumerable<AppUser>> GetAllFollowersOfForumThread(int threadId)
        {
            var follows = await _context.ForumThreadUserFollows.Where(f => f.ForumThreadId == threadId).Select(f => f.UserId).ToListAsync();
            var users = await _context.Users.Where(u => follows.Contains(u.Id)).ToListAsync();
            return users;
        }

        public async Task<int> GetAllThreadsCountFollowedByUser(string userId)
        {
            var follows = await _context.ForumThreadUserFollows.Where(f => f.UserId == userId).Select(f => f.ForumThreadId).ToListAsync();
            return (follows != null) ? follows.Count() : 0;
        }

        public async Task<IEnumerable<ForumThread>> GetAllThreadsFollowedByUser(string userId)
        {
            var follows = await _context.ForumThreadUserFollows.Where(f => f.UserId == userId).Select(f => f.ForumThreadId).ToListAsync();
            var threads = await _context.ForumThreads.Where(t => follows.Contains(t.Id)).ToListAsync();
            return threads;
        }

        public bool Save()
        {
            return _context.SaveChanges() > 1;
        }

        public bool Update(ForumThreadUserFollow entity)
        {
            _context.Update(entity);
            return Save();
        }
    }
}
