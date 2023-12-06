namespace ForumWebApp.Models
{
    public class ForumThreadUserFollow
    {
        public string UserId { get; set; }
        public int ForumThreadId { get; set; }

        public AppUser User { get; set; } = null!;
        public ForumThread ForumThread { get; set; } = null!;
    }
}
