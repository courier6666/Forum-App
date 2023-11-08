using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ForumWebApp.Data.Enums;

namespace ForumWebApp.Models
{
    public class ThreadPost
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public ICollection<Comment> Comments { get; set; }
        [ForeignKey("AppUser")]
        public string? AuthorId { get; set; }
        public AppUser Author { get; set; }
        [ForeignKey("ForumThread")]
        public int? ThreadId { get; set;}
        public ForumThread? ForumThread { get; set; }
        public DateTime CreateAtUtc { get; set; }
        public ICollection<Vote> Votes { get; set; }
        public ICollection<Vote> GetVotesOfType(VoteType voteType)
        {
            if (Votes == null) return new List<Vote>();
            return Votes.Where(v => v.VoteType == voteType).ToList();
        }

    }
}
