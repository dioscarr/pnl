using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using pnl.Data;
using pnl.Data.Models;

namespace pnl.Areas.PnlAccess.Pages
{
    public class CreateModel : PageModel
    {
        private readonly pnl.Data.ApplicationDbContext _context;

        public CreateModel(pnl.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public TaxForm TaxForm { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TaxForms.Add(TaxForm);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
