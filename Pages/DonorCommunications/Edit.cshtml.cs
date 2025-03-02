using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BloodDonationManagementSystem.Data;
using BloodDonationManagementSystem.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BloodDonationManagementSystem.Pages.DonorCommunications
{
    public class EditModel : PageModel
    {
        private readonly AppDbContext _context;

        public EditModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DonorCommunication DonorCommunication { get; set; }

        public SelectList Donors { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            DonorCommunication = await _context.DonorCommunications
                .Include(d => d.Donor)
                .FirstOrDefaultAsync(d => d.CommunicationID == id);

            if (DonorCommunication == null)
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

            _context.Attach(DonorCommunication).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}