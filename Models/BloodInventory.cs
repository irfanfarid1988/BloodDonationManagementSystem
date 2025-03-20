using System;
using System.ComponentModel.DataAnnotations;

namespace BloodDonationManagementSystem.Models
{
    public class BloodInventory
    {
        [Key]
        public int InventoryID { get; set; }

        [Required]
        [StringLength(5)]
        public string BloodGroup { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ExpirationDate { get; set; }

        public int? DonorID { get; set; } // Optional, to track donor contribution

        [DataType(DataType.DateTime)]
        public DateTime AddedDate { get; set; } = DateTime.Now;

        public Donor Donor { get; set; }
    }
}