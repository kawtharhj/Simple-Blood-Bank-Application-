using BloodBank.Data;
using BloodBank.Migrations;
using BloodBank.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Internal;
using Client = BloodBank.Models.Client;

namespace BloodBank.Pages
{
    public class ContactModel : PageModel
    {
        private readonly BloodBankContext _context;

        public ContactModel(BloodBankContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Client Client { get; set; } = new Client();

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Client == null || Client == null)
            {
                return Page();
            }

            _context.Client.Add(Client);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}


