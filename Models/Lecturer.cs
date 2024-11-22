using System.ComponentModel.DataAnnotations;

namespace ContractMonthlyClaimSystem.HR.Models
{
    public class Lecturer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string ContactNumber { get; set; }

        public string Department { get; set; }
    }
}
