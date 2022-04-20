using System.ComponentModel.DataAnnotations;

namespace CorrectifSecu_API.Models
{
    public class FormCreateBeer
    {
        [Required]
        public string Name { get; set; }
        
        [Required]
        public decimal Degree { get; set; }
        
        [Required]
        public string Origin { get; set; }
    }
}
