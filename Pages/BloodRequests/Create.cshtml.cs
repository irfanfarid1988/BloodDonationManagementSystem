using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BloodDonationManagementSystem.Models;
using BloodDonationManagementSystem.Data;

namespace BloodDonationManagementSystem.Pages.BloodRequests
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _context;

        public CreateModel(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            BloodRequest = new BloodRequest { RequestDate = System.DateTime.Now };
            return Page();
        }

        [BindProperty]
        public BloodRequest BloodRequest { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.BloodRequests.Add(BloodRequest);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}