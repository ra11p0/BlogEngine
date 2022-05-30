using System.ComponentModel.DataAnnotations;

namespace BlogEngine.ViewModels.Account
{
    public class LoginViewModel
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        public string? ReturnUrl { get; set; }
    }
}
