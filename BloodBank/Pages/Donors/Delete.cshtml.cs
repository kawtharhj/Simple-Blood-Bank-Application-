using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BloodBank.Data;
using BloodBank.Models;

namespace BloodBank.Pages.Donors
{
    public class DeleteModel : PageModel
    {
        private readonly BloodBank.Data.BloodBankContext _context;

        public DeleteModel(BloodBank.Data.BloodBankContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Donor Donor { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Donor == null)
            {
                return NotFound();
            }

            var donor = await _context.Donor.FirstOrDefaultAsync(m => m.ID == id);

            if (donor == null)
            {
                return NotFound();
            }
            else 
            {
                Donor = donor;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Donor == null)
            {
                return NotFound();
            }
            var donor = await _context.Donor.FindAsync(id);

            if (donor != null)
            {
                Donor = donor;
                _context.Donor.Remove(Donor);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
