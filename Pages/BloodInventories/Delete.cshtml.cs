using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BloodDonationManagementSystem.Data;
using BloodDonationManagementSystem.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BloodDonationManagementSystem.Pages.BloodInventories
{
    public class DeleteModel : PageModel
    {
        private readonly AppDbContext _context;

        public DeleteModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BloodInventory BloodInventory { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            BloodInventory = await _context.BloodInventories
                .Include(b => b.Donor)
                .FirstOrDefaultAsync(b => b.InventoryID == id);

            if (BloodInventory == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            BloodInventory = await _context.BloodInventories.FindAsync(id);

            if (BloodInventory != null)
            {
                _context.BloodInventories.Remove(BloodInventory);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}