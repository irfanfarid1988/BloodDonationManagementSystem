using System;
using System.ComponentModel.DataAnnotations;

public class DonorCommunication
{
    [Key]
    public int CommunicationID { get; set; }

    [Required]
    public int DonorID { get; set; }

    [Required]
    [DataType(DataType.DateTime)]
    public DateTime CommunicationDate { get; set; } = DateTime.Now;

    [Required]
    [StringLength(50)]
    public string MessageType { get; set; } // e.g., Email, SMS, Call

    [Required]
    [StringLength(1000)]
    public string Message { get; set; }

    [Required]
    [StringLength(20)]
    public string Status { get; set; } = "Sent"; // e.g., Sent, Delivered, Failed

    public Donor Donor { get; set; }
}