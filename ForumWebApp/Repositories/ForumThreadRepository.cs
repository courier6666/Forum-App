using ForumWebApp.Data;
using ForumWebApp.Interfaces;
using ForumWebApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ForumWebApp.Repositories
{
    public class ForumThreadRepository : IForumThreadRepository
    {
        ApplicationDbContext _context;
        public ForumThreadRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(ForumThread entity)
        {
            _context.Add(entity);
            return Save();
        }

        public bool Delete(ForumThread entity)
        {
            _context.Remove(entity);
            return Save();
        } 

        public async Task<IEnumerable<ForumThread>> GetAllAsync()
        {
            var threads =  await _context.ForumThreads.Include(t=>t.Posts).ToListAsync();

            foreach(var thread in threads)
            {
                foreach(var post in thread.Posts)
                {
                    await LoadCommentsWithReplies(post.Comments);
                }
            }
            return threads;
        }
        private async Task LoadCommentsWithReplies(ICollection<Comment> comments)
        {
            foreach(var comment in comments)
            {
                await _context.Entry(comment).Collection(c => c.Replies).LoadAsync();

                if (comment.Replies.Any())
                    await LoadCommentsWithReplies(comment.Replies.ToList());
            }
        }

        public async Task<ForumThread> GetByIdAsync(int id)
        {
            var thread = await _context.ForumThreads
                .Include(t => t.Posts)
                    .ThenInclude(post => post.Comments)
                .Include(t => t.Posts)
                    .ThenInclude(post => post.Author).
                FirstOrDefaultAsync(t => t.Id == id);


            foreach (var post in thread.Posts)
            {
                await LoadCommentsWithReplies(post.Comments);
            }
            return thread;
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

        public bool Update(ForumThread entity)
        {
            _context.Update(entity);
            return Save();
        }

        public async Task<IEnumerable<ForumThread>> GetAllThreadsFollowedByUser(string userId)
        {
            var follows = await _context.ForumThreadUserFollows.Where(f => f.UserId == userId).Select(f => f.ForumThreadId).ToListAsync();
            var threads = await _context.ForumThreads.Where(t => follows.Contains(t.Id)).ToListAsync();
            return threads;
        }

        public async Task<int> GetAllThreadsCountFollowedByUser(string userId)
        {
            var follows = await _context.ForumThreadUserFollows.Where(f => f.UserId == userId).Select(f => f.ForumThreadId).ToListAsync();
            return (follows != null) ? follows.Count() : 0;
        }

        public async Task<bool> IsThreadFollowedByUser(int threadId, string userId)
        {
            var follows = await _context.ForumThreadUserFollows.FirstOrDefaultAsync(f => (f.UserId == userId && f.ForumThreadId == threadId));
            return follows != null;
        }
    }
}
