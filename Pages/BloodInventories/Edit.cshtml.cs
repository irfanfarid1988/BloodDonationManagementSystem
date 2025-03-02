using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BloodDonationManagementSystem.Data;
using BloodDonationManagementSystem.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BloodDonationManagementSystem.Pages.BloodInventories
{
    public class EditModel : PageModel
    {
        private readonly AppDbContext _context;

        public EditModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BloodInventory BloodInventory { get; set; }

        public SelectList Donors { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            BloodInventory = await _context.BloodInventories
                .Include(b => b.Donor)
                .FirstOrDefaultAsync(b => b.InventoryID == id);

            if (BloodInventory == null)
            {
                return NotFound();
            }

            Donors = new SelectList(await _context.Donors.ToListAsync(), "DonorID", "FullName");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Donors = new SelectList(await _context.Donors.ToListAsync(), "DonorID", "FullName");
                return Page();
            }

            _context.Attach(BloodInventory).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}