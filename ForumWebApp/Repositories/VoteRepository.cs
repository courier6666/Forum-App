using ForumWebApp.Data;
using ForumWebApp.Data.Enums;
using ForumWebApp.Interfaces;
using ForumWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ForumWebApp.Repositories
{
    public class VoteRepository : IVoteRepository
    {
        ApplicationDbContext _context;
        public VoteRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(Vote entity)
        {
            _context.Add(entity);
            return Save();
        }

        public bool Delete(Vote entity)
        {
            _context.Remove(entity);
            return Save();
        }

        public async Task<Vote> GetVoteByUserAndPost(string userId, int postId)
        {
            var vote = await _context.Votes.Where(v => v.PostId == postId).Where(v=>v.AuthorId==userId).FirstOrDefaultAsync();
            return vote;
        }

        public async Task<IEnumerable<Vote>> GetAllAsync()
        {
            var votes = await _context.Votes.Include(v=>v.Author).ToListAsync();
            return votes;
        }

        public async Task<ICollection<Vote>> GetAllCommentVotesOfType(int commentId, VoteType voteType)
        {
            var votes = await _context.Votes.Where(v=>v.CommentId == commentId).
                Where(v => v.VoteType == voteType).
                ToListAsync();
            return votes;
        }

        public async Task<ICollection<Vote>> GetAllPostVotesOfType(int postId, VoteType voteType)
        {
            var votes = await _context.Votes.Where(v => v.PostId == postId).
                Where(v => v.VoteType == voteType).
                ToListAsync();
            return votes;
        }

        public async Task<Vote> GetByIdAsync(int id)
        {
            var vote = await _context.Votes.Include(v=>v.Author).
                FirstOrDefaultAsync(v => v.Id == id);
            return vote;
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

        public bool Update(Vote entity)
        {
            _context.Update(entity);
            return Save();
        }

        public async Task<Vote> GetVoteByUserAndComment(string userId, int commentId)
        {
            var vote = await _context.Votes.Where(v => v.AuthorId == userId && v.CommentId == commentId).FirstOrDefaultAsync();
            return vote;
        }
    }
}
