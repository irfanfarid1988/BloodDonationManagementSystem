using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BloodDonationManagementSystem.Data;
using BloodDonationManagementSystem.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BloodDonationManagementSystem.Pages.DonorCommunications
{
    public class DeleteModel : PageModel
    {
        private readonly AppDbContext _context;

        public DeleteModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DonorCommunication DonorCommunication { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            DonorCommunication = await _context.DonorCommunications
                .Include(d => d.Donor)
                .FirstOrDefaultAsync(d => d.CommunicationID == id);

            if (DonorCommunication == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            DonorCommunication = await _context.DonorCommunications.FindAsync(id);

            if (DonorCommunication != null)
            {
                _context.DonorCommunications.Remove(DonorCommunication);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}