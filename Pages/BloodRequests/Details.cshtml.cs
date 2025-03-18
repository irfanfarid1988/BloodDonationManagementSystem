using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BloodDonationManagementSystem.Models;
using System.Threading.Tasks;
using BloodDonationManagementSystem.Data;

namespace BloodDonationManagementSystem.Pages.BloodRequests
{
    public class DetailsModel : PageModel
    {
        private readonly AppDbContext _context;

        public DetailsModel(AppDbContext context)
        {
            _context = context;
        }

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
    }
}