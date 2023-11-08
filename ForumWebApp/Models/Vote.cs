using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ForumWebApp.Data.Enums;

namespace ForumWebApp.Models
{
    public class Vote
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("AppUser")]
        public string? AuthorId { get; set; }
        public AppUser? Author { get; set; }
        [ForeignKey("ThreadPost")]
        public int? PostId { get; set; }
        public ThreadPost? Post { get; set; }
        [ForeignKey("Comment")]
        public int? CommentId { get; set; }
        public Comment? Comment { get; set; }
        public DateTime CreateAtUtc { get; set; }
        public VoteType? VoteType { get; set; }

    }
}
