using System.ComponentModel.DataAnnotations;

namespace ForumWebApp.ViewModels
{
    public class LoginUserViewModel
    {
        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Email address is required!")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
