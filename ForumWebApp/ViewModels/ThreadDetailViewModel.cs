﻿using ForumWebApp.Models;
using System.Security.Policy;

namespace ForumWebApp.ViewModels
{
    public class ThreadDetailViewModel
    {
        public int Id { get; set;}
        public string Title { get; set;}
        public string Description { get; set;}
        public ICollection<ThreadPost> Posts { get; set;}
        public int NumberOfFollowers { get; set; }
        public bool IsFollowing { get; set; }
        public bool IsUserLoggedIn { get; set; }
    }
}
