using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BloodDonationManagementSystem.Data;
using BloodDonationManagementSystem.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BloodDonationManagementSystem.Pages.Appointments
{
    public class EditModel : PageModel
    {
        private readonly AppDbContext _context;

        public EditModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Appointment Appointment { get; set; }

        public SelectList Donors { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Appointment = await _context.Appointments
                .Include(a => a.Donor)
                .FirstOrDefaultAsync(a => a.AppointmentID == id);

            if (Appointment == null)
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

            _context.Attach(Appointment).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}