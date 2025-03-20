using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloodDonationManagementSystem.Models
{
	public class BloodRequest
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[Display(Name = "Patient Name")]
		public string PatientName { get; set; }

		[Required]
		[Display(Name = "Blood Group")]
		public string BloodGroup { get; set; }

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