using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class AddEmployee
    {
        [Required]
        public string Name { get; set; }

        [Required(ErrorMessage = "Duplicate Civil ID ")]
        public int CivilId { get; set; }
        [Required]
        public string Position { get; set; } 
    }
}