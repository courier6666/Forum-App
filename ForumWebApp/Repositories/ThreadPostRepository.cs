﻿
using ForumWebApp.Data;
using ForumWebApp.Interfaces;
using ForumWebApp.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Xml.Linq;
using ForumWebApp.ViewModels;

namespace ForumWebApp.Repositories
{
    public class ThreadPostRepository : IThreadPostRepository
    {
        private readonly ApplicationDbContext _context;
        public ThreadPostRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(ThreadPost entity)
        {
            _context.Add(entity);
            return Save();
        }

        public bool Delete(ThreadPost entity)
        {
            _context.Remove(entity);
            return Save();
        }

        public async Task<IEnumerable<ThreadPost>> GetAllAsync()
        {
            return await _context.ThreadPosts.ToListAsync();
        }

        public async Task<ThreadPost> GetByIdAsync(int id)
        {
            var post = await _context.ThreadPosts.Include(p=>p.Author).Include(p => p.Comments).Include(p => p.Votes).FirstOrDefaultAsync(p => p.Id == id);
            await LoadCommentsWithReplies(post.Comments);
            return post;
        }

        public async Task<IEnumerable<ThreadPost>> GetPostsByThreadIdAsync(int threadId)
        {
            var posts = await _context.ThreadPosts.Where(p => p.ThreadId == threadId).Include(p => p.Comments).Include(p => p.Votes).ToListAsync();
            
            foreach(var post in posts) {
                await LoadCommentsWithReplies(post.Comments);
            }
            return posts;
        }
        private async Task LoadCommentsWithReplies(ICollection<Comment> comments)
        {
            foreach (var comment in comments)
            {
                await _context.Entry(comment).Collection(c => c.Replies).LoadAsync();
                await _context.Entry(comment).Collection(c => c.Votes).LoadAsync();
                await _context.Entry(comment).Reference(c => c.Author).LoadAsync();

                if (comment.Replies.Any())
                    await LoadCommentsWithReplies(comment.Replies.ToList());
            }
        }
        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

        public bool Update(ThreadPost entity)
        {
            _context.Update(entity);
            return Save();
        }
        
        public async Task<IEnumerable<ThreadPost>> GetAllPostsFromThreadsFollowedByUserWithinTimePeriod(string userId, TimeSpan start, TimeSpan end)
        {
            var followedThreads = await _context.ForumThreadUserFollows.
                Where(f=>f.UserId == userId).
                Select(f=>f.ForumThreadId).
                ToListAsync();

            if (followedThreads == null) return null;
            var followedThreadsSet = new HashSet<int>(followedThreads);

            var posts = await _context.ThreadPosts.
                Where(p => p.ThreadId != null && followedThreadsSet.Contains((int)p.ThreadId)).
                ToListAsync();

            var currentTime = DateTime.Now;
            posts = posts.Where(p => ((currentTime - p.CreateAtUtc) > start && (currentTime - p.CreateAtUtc) <= end)).
                OrderBy(p => p.CreateAtUtc).ToList();

            return posts;
        }
    }
}
