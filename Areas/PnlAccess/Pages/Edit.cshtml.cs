using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using pnl.Data;
using pnl.Data.Models;

namespace pnl.Areas.PnlAccess.Pages
{
    public class EditModel : PageModel
    {
        private readonly pnl.Data.ApplicationDbContext _context;

        public EditModel(pnl.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TaxForm TaxForm { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TaxForm = await _context.TaxForms.FirstOrDefaultAsync(m => m.ID == id);

            if (TaxForm == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TaxForm).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaxFormExists(TaxForm.ID))
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

        private bool TaxFormExists(int id)
        {
            return _context.TaxForms.Any(e => e.ID == id);
        }
    }
}
