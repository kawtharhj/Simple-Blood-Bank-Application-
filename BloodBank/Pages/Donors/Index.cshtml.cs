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
    public class IndexModel : PageModel
    {
        private readonly BloodBank.Data.BloodBankContext _context;

        public IndexModel(BloodBank.Data.BloodBankContext context)
        {
            _context = context;
        }

        public IList<Donor> Donor { get; set; } = default!;

        [BindProperty(SupportsGet = true)]

        public string? BloodGroup { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? SearchCountry { get; set; }



        public async Task OnGetAsync()
        {


            var donors = from d in _context.Donor
                         select d;

            if (!string.IsNullOrEmpty(SearchCountry))
            {
                donors = donors.Where(d => d.Country == SearchCountry);
            }

            Donor = await donors.ToListAsync();

            var bg = from b in _context.Donor
                     select b;
            if (!string.IsNullOrEmpty(BloodGroup))
            {
                donors = donors.Where(d => d.BloodGroup == BloodGroup);
            }

            Donor = await donors.ToListAsync();

        }

    }
}
