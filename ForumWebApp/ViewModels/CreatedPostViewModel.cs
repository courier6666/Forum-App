using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace ForumWebApp.ViewModels
{
    public class CreatedPostViewModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        public int ThreadId { get; set; }
        public string? AuthorId { get; set; }
    }
}
