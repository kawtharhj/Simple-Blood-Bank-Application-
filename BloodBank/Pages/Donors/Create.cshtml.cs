using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BloodBank.Data;
using BloodBank.Models;

namespace BloodBank.Pages.Donors
{
    public class CreateModel : PageModel
    {
        private readonly BloodBank.Data.BloodBankContext _context;

        public CreateModel(BloodBank.Data.BloodBankContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Donor Donor { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Donor == null || Donor == null)
            {
                return Page();
            }

            _context.Donor.Add(Donor);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
