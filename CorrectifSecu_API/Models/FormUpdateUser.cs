using System.ComponentModel.DataAnnotations;

namespace CorrectifSecu_API.Models
{
    public class FormUpdateUser
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Nickname { get; set; }

        [Required]
        public string Role { get; set; }
    }
}
