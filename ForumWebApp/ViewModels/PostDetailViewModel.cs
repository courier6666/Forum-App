using ForumWebApp.Models;

namespace ForumWebApp.ViewModels
{
    public class PostDetailViewModel
    {
        public ThreadPost Post { get; set; }
        public IHttpContextAccessor HttpContextAccessor { get; set; }
    }
}
