using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class NewBranchForm
    {
        [Required]
        [Display(Name = "Location Name: ")]
        public string LocationName { get; set; }
        [Required]
        [Display(Name = "Location URL : ")]
        public string LocationURL { get; set; }
        [Required]
        [Display(Name = "Branch Manager: ")]
        public string BranchManager { get; set; }
        [Range(1, 40)]
        [Display(Name = "Employees Count: ")]
        public int EmployeeCount { get; set; }
     
    }
}
