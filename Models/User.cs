using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BloodDonationManagementSystem.Models
{
    public class User : IdentityUser
    {
        [Key]
        public int UserID { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }
    }
}