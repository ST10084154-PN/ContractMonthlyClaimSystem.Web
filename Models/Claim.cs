using System.ComponentModel.DataAnnotations;

namespace ContractMonthlyClaimSystem.HR.Models
{
    public class Claim
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int LecturerId { get; set; }

        [Required]
        public string LecturerName { get; set; }

        [Required]
        public int HoursWorked { get; set; }

        [Required]
        public double HourlyRate { get; set; }

        public double TotalAmount { get; set; }
        public string Status { get; set; } = "Pending";
    }
}
