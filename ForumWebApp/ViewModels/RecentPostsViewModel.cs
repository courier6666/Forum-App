using ForumWebApp.Models;

namespace ForumWebApp.ViewModels
{
    public class RecentPostsViewModel
    {
        public ICollection<ThreadPost> RecentPosts { get; set; }
    }
}
