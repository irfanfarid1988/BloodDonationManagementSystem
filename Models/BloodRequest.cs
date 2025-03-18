using System;
using System.ComponentModel.DataAnnotations;

namespace BloodDonationManagementSystem.Models
{
    public class BloodRequest
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Patient Name")]
        public string PatientName { get; set; }

        [Required]
        [Display(Name = "Blood Type")]
        public string BloodType { get; set; }

        [Required]
        [Display(Name = "Units Needed")]
        public int UnitsNeeded { get; set; }

        [Required]
        [Display(Name = "Urgency Level")]
        public string UrgencyLevel { get; set; }

        [Required]
        [Display(Name = "Request Date")]
        [DataType(DataType.Date)]
        public DateTime RequestDate { get; set; }
        public string RequestStatus { get; set; } = "Pending";

        public DateTime? RequestedAt { get; set; } = DateTime.Now;
    }
}