using Microsoft.EntityFrameworkCore;
using BloodDonationManagementSystem.Models;

namespace BloodDonationManagementSystem.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Donor> Donors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<BloodInventory> BloodInventories { get; set; }
        public DbSet<DonorCommunication> DonorCommunications { get; set; }
        public DbSet<User> Users { get; set; }
    }
}