using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class EditBankBranch
    {
        [Required]
        public int BankId { get; set; }
        [Required]
        public string LocationName { get; set; }
        [Required]
        public string LocationURL { get; set; }
        [Required]
        public string BranchManager { get; set; }
        [Required]
        public int EmployeeCount { get; set; }
    }
}
