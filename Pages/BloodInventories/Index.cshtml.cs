using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BloodDonationManagementSystem.Data;
using BloodDonationManagementSystem.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BloodDonationManagementSystem.Pages.BloodInventories
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<BloodInventory> BloodInventories { get; set; }

        public async Task OnGetAsync()
        {
            BloodInventories = await _context.BloodInventories
                .Include(b => b.Donor)
                .ToListAsync();
        }
    }
}