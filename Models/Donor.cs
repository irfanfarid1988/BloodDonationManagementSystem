using System;
using System.ComponentModel.DataAnnotations;

namespace BloodDonationManagementSystem.Models
{
    public class Donor
    {
        [Key]
        public int DonorID { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        [Required]
        [RegularExpression(@"^(A|B|AB|O)[+-]$")]
        public string BloodGroup { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        public string? State { get; set; }
        public string? City { get; set; }
        public string? Address { get; set; }
        public string? MedicalHistory { get; set; }

        public string? Gender { get; set; }

        [Required]
        [Phone]
        public string? ContactNumber { get; set; }

        public DateTime RegistrationDate { get; set; } = DateTime.Now;
        public DateTime? LastDonationDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;
    }
}