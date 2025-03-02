using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BloodDonationManagementSystem.Data;
using BloodDonationManagementSystem.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BloodDonationManagementSystem.Pages.DonorCommunications
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _context;

        public CreateModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DonorCommunication DonorCommunication { get; set; }

        public SelectList Donors { get; set; }

        public async Task OnGetAsync()
        {
            Donors = new SelectList(await _context.Donors.ToListAsync(), "DonorID", "FullName");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Donors = new SelectList(await _context.Donors.ToListAsync(), "DonorID", "FullName");
                return Page();
            }

            _context.DonorCommunications.Add(DonorCommunication);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}