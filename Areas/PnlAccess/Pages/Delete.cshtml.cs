using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using pnl.Data;
using pnl.Data.Models;

namespace pnl.Areas.PnlAccess.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly pnl.Data.ApplicationDbContext _context;

        public DeleteModel(pnl.Data.ApplicationDbContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TaxForm = await _context.TaxForms.FindAsync(id);

            if (TaxForm != null)
            {
                _context.TaxForms.Remove(TaxForm);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
