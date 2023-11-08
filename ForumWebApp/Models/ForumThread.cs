using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ForumWebApp.Models
{
    public class ForumThread
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public ICollection<ThreadPost> Posts { get; set; }
        [ForeignKey("AppUser")]
        public string? AuthorId { get; set; }
        public AppUser Author { get; set; }
    }
}
