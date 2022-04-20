using System.ComponentModel.DataAnnotations;

namespace CorrectifSecu_API.Models
{
    public class FormRegister
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Nickname { get; set; }

        public IEnumerable<int> FavoriteId {get; set;}
    }
}
