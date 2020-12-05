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
    public class IndexModel : PageModel
    {
        private readonly pnl.Data.ApplicationDbContext _context;

        public IndexModel(pnl.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<TaxForm> TaxForm { get;set; }

        public async Task OnGetAsync()
        {
            TaxForm = await _context.TaxForms.ToListAsync();
        }
    }
}
