using ForumWebApp.Data.Enums;

namespace ForumWebApp.ViewModels
{
    public class VoteAddedViewModel
    {
        public VoteType VoteType { get; set; }
        public string AuthorId { get; set; }
        public int? PostId { get; set; }
        public int? CommentId { get; set; }
    }
}
