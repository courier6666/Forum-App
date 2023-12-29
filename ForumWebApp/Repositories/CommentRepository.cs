using ForumWebApp.Data;
using ForumWebApp.Interfaces;
using ForumWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ForumWebApp.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _context;
        public CommentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(Comment entity)
        {
            _context.Add(entity);
            return Save();
        }

        private void RecursiveDelete(Comment entity)
        {
            if (entity?.Replies == null) return;
            foreach(var reply in entity.Replies)
            {
                RecursiveDelete(reply);
            }
            _context.Remove(entity);
        }

        public bool Delete(Comment entity)
        {
            RecursiveDelete(entity); 
            return Save();
        }

        public async Task<IEnumerable<Comment>> GetAllAsync()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<IEnumerable<Comment>> GetAllCommentsByPostId(int postId)
        {
            return await _context.Comments.Where(c => c.PostId == postId).
                Include(c => c.Replies).
                ToListAsync();
        }

        public async Task<Comment> GetByIdAsync(int id)
        {
            return await _context.Comments.Include(c => c.Replies).
                Include(c=>c.Author).FirstOrDefaultAsync(c => c.Id == id);
        }
        public async Task<IEnumerable<Comment>> GetRepliesOfCommentById(int id)
        {
            return await _context.Comments.Where(c => c.ParentCommentId == id).
                Include(c => c.Replies).
                Include(c=>c.Votes).Include(c=>c.Author).
                ToListAsync();
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

        public bool Update(Comment entity)
        {
            _context.Update(entity);
            return Save();
        }

        public async Task<Comment> GetByIdNoTracking(int id)
        {
            return await _context.Comments.Include(c => c.Replies).AsNoTracking().
                FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
