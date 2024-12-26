using System.ComponentModel.DataAnnotations;

namespace Bookstore_Backend_C_.Models
{
    public class SignupModel
    {
        [Required]
        public string Fullname { get; set; }
        [Required]
        public string Username { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, Compare("ConfirmPassword")]
        public string Password { get; set; }
        public string? ConfirmPassword { get; set; }
    }
}
