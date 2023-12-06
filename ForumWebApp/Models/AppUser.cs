using ForumWebApp.Interfaces.Observer;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ForumWebApp.Models
{
    public class AppUser : IdentityUser
    {
        public ICollection<ForumThread> Threads { get; set; }
        public ICollection<ThreadPost> Posts { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Vote> Votes { get; set; }
        public string? ProfileImageUrl { get; set; }
        public ICollection<ForumThread> FollowedThreads { get; set; }

    }
}
