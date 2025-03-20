using System;
using System.ComponentModel.DataAnnotations;
namespace BloodDonationManagementSystem.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentID { get; set; }

        [Required]
        public int DonorID { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime AppointmentDate { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public TimeSpan AppointmentTime { get; set; }

        [Required]
        [StringLength(20)]
        public string Status { get; set; } = "Scheduled"; // e.g., Scheduled, Completed, Cancelled

        [StringLength(500)]
        public string Notes { get; set; }

        public Donor Donor { get; set; }
    }
}