using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BloodDonationManagementSystem.Data;
using BloodDonationManagementSystem.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BloodDonationManagementSystem.Pages.DonorCommunications
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<DonorCommunication> DonorCommunications { get; set; }

        public async Task OnGetAsync()
        {
            DonorCommunications = await _context.DonorCommunications
                .Include(d => d.Donor)
                .ToListAsync();
        }
    }
}