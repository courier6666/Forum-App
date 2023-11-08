
using ForumWebApp.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Security.Policy;
using System.Text.Json.Serialization;

namespace ForumWebApp.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public string? Content { get; set; }
        [ForeignKey("AppUser")]
        public string? AuthorId { get; set; }
        public AppUser? Author { get; set; }
        [ForeignKey("ThreadPost")]
        public int? PostId { get; set; }
        public ThreadPost? Post { get; set; }
        [ForeignKey("Comment")]
        public int? ParentCommentId { get; set; }
        public Comment? ParentComment { get; set; }
        public ICollection<Comment> Replies { get; set; }
        public ThreadPost GetThreadPost()
        {
            if (Post != null) return Post;

            return ParentComment?.GetThreadPost();
        }
        public ICollection<Vote> Votes { get; set; }
        public DateTime CreateAtUtc { get; set; }
        public ICollection<Vote> GetVotesOfType(VoteType voteType)
        {
            if (Votes == null) return new List<Vote>();
            return Votes.Where(v => v.VoteType == voteType).ToList();
        }
    }
}
