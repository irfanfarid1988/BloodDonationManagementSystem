using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BloodDonationManagementSystem.Data;
using BloodDonationManagementSystem.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BloodDonationManagementSystem.Pages.Donors
{
    public class DeleteModel : PageModel
    {
        private readonly AppDbContext _context;

        public DeleteModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Donor Donor { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Donor = await _context.Donors.FindAsync(id);

            if (Donor == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            Donor = await _context.Donors.FindAsync(id);

            if (Donor != null)
            {
                _context.Donors.Remove(Donor);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}