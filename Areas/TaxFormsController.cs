using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using pnl.Data;
using pnl.Data.Models;

namespace pnl.Areas
{
    [Area("TaxFormsController.cs")]
    public class TaxFormsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TaxFormsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TaxFormsController.cs/TaxForms
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TaxForms.Include(t => t.Filingstatus).Include(t => t.Person);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TaxFormsController.cs/TaxForms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taxForm = await _context.TaxForms
                .Include(t => t.Filingstatus)
                .Include(t => t.Person)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (taxForm == null)
            {
                return NotFound();
            }

            return View(taxForm);
        }

        // GET: TaxFormsController.cs/TaxForms/Create
        public IActionResult Create()
        {
            ViewData["FilingStatusID"] = new SelectList(_context.FilingStatus, "Id", "Id");
            ViewData["PersonID"] = new SelectList(_context.Person, "id", "id");
            return View();
        }

        // POST: TaxFormsController.cs/TaxForms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,UserID,TaxYear,isFiled,FilingStatus,PersonID,FilingStatusID")] TaxForm taxForm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taxForm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FilingStatusID"] = new SelectList(_context.FilingStatus, "Id", "Id", taxForm.FilingStatusID);
            ViewData["PersonID"] = new SelectList(_context.Person, "id", "id", taxForm.PersonID);
            return View(taxForm);
        }

        // GET: TaxFormsController.cs/TaxForms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taxForm = await _context.TaxForms.FindAsync(id);
            if (taxForm == null)
            {
                return NotFound();
            }
            ViewData["FilingStatusID"] = new SelectList(_context.FilingStatus, "Id", "Id", taxForm.FilingStatusID);
            ViewData["PersonID"] = new SelectList(_context.Person, "id", "id", taxForm.PersonID);
            return View(taxForm);
        }

        // POST: TaxFormsController.cs/TaxForms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,UserID,TaxYear,isFiled,FilingStatus,PersonID,FilingStatusID")] TaxForm taxForm)
        {
            if (id != taxForm.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taxForm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaxFormExists(taxForm.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["FilingStatusID"] = new SelectList(_context.FilingStatus, "Id", "Id", taxForm.FilingStatusID);
            ViewData["PersonID"] = new SelectList(_context.Person, "id", "id", taxForm.PersonID);
            return View(taxForm);
        }

        // GET: TaxFormsController.cs/TaxForms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taxForm = await _context.TaxForms
                .Include(t => t.Filingstatus)
                .Include(t => t.Person)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (taxForm == null)
            {
                return NotFound();
            }

            return View(taxForm);
        }

        // POST: TaxFormsController.cs/TaxForms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var taxForm = await _context.TaxForms.FindAsync(id);
            _context.TaxForms.Remove(taxForm);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaxFormExists(int id)
        {
            return _context.TaxForms.Any(e => e.ID == id);
        }
    }
}
