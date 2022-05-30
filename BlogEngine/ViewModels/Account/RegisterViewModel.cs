using System.ComponentModel.DataAnnotations;

namespace BlogEngine.ViewModels.Account
{
    public class RegisterViewModel
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string PasswordConfirm { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public bool AcceptedTnC { get; set; }
    }
}
