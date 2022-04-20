using System.ComponentModel.DataAnnotations;

namespace CorrectifSecu_API.Models
{
    public class FormLogin
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
