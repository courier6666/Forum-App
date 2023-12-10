using ForumWebApp.Models;

namespace ForumWebApp.ViewModels
{
    public class RecentPostsViewModel
    {
        public ICollection<(string, ICollection<ThreadPost>)> RecentPostsByEachPeriod { get; set; }
    }
}
