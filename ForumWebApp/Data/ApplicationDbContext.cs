using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ForumWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Policy;
using ForumWebApp.Extensions;
using CloudinaryDotNet;

namespace ForumWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<ForumThread> ForumThreads { get; set; }
        public DbSet<ThreadPost> ThreadPosts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public bool ClearAllData()
        {
            ForumThreads.ClearDbSet();
            ThreadPosts.ClearDbSet();
            Comments.ClearDbSet();
            Votes.ClearDbSet();
            return this.SaveChanges() > 0;
        }
    }
}
