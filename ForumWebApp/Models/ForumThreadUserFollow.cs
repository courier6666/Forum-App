using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForumWebApp.Models
{
    public class ForumThreadUserFollow
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("AppUser")]
        public string UserId { get; set; }
        [ForeignKey("ForumThread")]
        public int ForumThreadId { get; set; }

        public AppUser User { get; set; } = null!;
        public ForumThread ForumThread { get; set; } = null!;
    }
}
