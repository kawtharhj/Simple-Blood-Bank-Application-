using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BloodBank.Data;
using BloodBank.Models;

namespace BloodBank.Pages.Donors
{
    public class EditModel : PageModel
    {
        private readonly BloodBank.Data.BloodBankContext _context;

        public EditModel(BloodBank.Data.BloodBankContext context)
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

            var donor =  await _context.Donor.FirstOrDefaultAsync(m => m.ID == id);
            if (donor == null)
            {
                return NotFound();
            }
            Donor = donor;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Donor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DonorExists(Donor.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DonorExists(int id)
        {
          return (_context.Donor?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
