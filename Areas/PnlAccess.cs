using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pnl.Areas
{
    public class PnlAccess : Controller
    {
        // GET: PnlAccess
        public ActionResult Index()
        {
            return View();
        }

        // GET: PnlAccess/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PnlAccess/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PnlAccess/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PnlAccess/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PnlAccess/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PnlAccess/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PnlAccess/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
