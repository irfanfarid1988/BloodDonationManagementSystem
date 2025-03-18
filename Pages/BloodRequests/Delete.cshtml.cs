using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BloodDonationManagementSystem.Models;
using System.Threading.Tasks;
using BloodDonationManagementSystem.Data;

namespace BloodDonationManagementSystem.Pages.BloodRequests
{
    public class DeleteModel : PageModel
    {
        private readonly AppDbContext _context;

        public DeleteModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BloodRequest BloodRequest { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BloodRequest = await _context.BloodRequests.FirstOrDefaultAsync(m => m.Id == id);

            if (BloodRequest == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BloodRequest = await _context.BloodRequests.FindAsync(id);

            if (BloodRequest != null)
            {
                _context.BloodRequests.Remove(BloodRequest);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}