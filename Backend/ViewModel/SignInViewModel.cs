using System.ComponentModel.DataAnnotations;

namespace Backend.ViewModel
{
    public class SignInViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        public string Password { get; set; }
    }
}