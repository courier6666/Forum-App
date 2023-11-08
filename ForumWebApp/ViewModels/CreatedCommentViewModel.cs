using ForumWebApp.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ForumWebApp.ViewModels
{
    public class CreatedCommentViewModel
    {
        public string Content { get; set; }
        public string AuthorId { get; set; }
        public int? PostId { get; set; }
        public int? ParentCommentId { get; set; }
    }
}
