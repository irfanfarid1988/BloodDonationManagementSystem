using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BloodDonationManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using BloodDonationManagementSystem.Data;

namespace BloodDonationManagementSystem.Pages.BloodRequests
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<BloodRequest> BloodRequests { get;set; }

        public async Task OnGetAsync()
        {
            BloodRequests = await _context.BloodRequests.ToListAsync();
        }
    }
}