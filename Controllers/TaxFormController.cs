using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using pnl.Data;
using pnl.Data.Models;
using pnl.Models;

namespace pnl.Controllers
{
    [Authorize]
    public class TaxFormController : Controller
    {
        private readonly ApplicationDbContext _db;
        public TaxFormController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: TaxFormController1
        public ActionResult Index()
        {
            var usrId = User.Claims.First().Value;
            TaxFormViewModel tfvm = new TaxFormViewModel();
            tfvm.Init(_db);
            if (_db.TaxForms.Any(c => c.TaxYear == DateTime.Now.Year && c.UserID == usrId && c.isFiled == false))
            {
                var t = _db.TaxForms.First(c => c.TaxYear == DateTime.Now.Year && c.UserID == usrId && c.isFiled == false);
                    return RedirectToAction(nameof(Create), new {id = t.ID, status = "Continue" });
            }
            tfvm.LoadTaxYears(usrId);
            return View(tfvm);
        }

        // GET: TaxFormController1/Details/5 
        public ActionResult Review(int id)
        {
            TaxFormViewModel tfvm = new TaxFormViewModel();
            tfvm.Init(_db);
            return View(tfvm.GetTaxById(id));           
        }

        // GET: TaxFormController1/Create
        [HttpGet]
        public ActionResult Create(int id,string status)
        {
            TaxFormViewModel tfvm = new TaxFormViewModel();            
            tfvm.CurrentTaxForm = _db.TaxForms.First(c => c.ID == id);
            ITaxFormViewModel sendback = tfvm;
            return View(sendback);
        }

        // POST: TaxFormController1/Create
        [HttpPost]
        public ActionResult Create(int selectedyear)
        {
            try
            {
                if (!_db.TaxForms.Any(c => c.TaxYear == selectedyear && c.UserID == User.Claims.First().Value))
                {
                    var f = _db.FilingStatus.First(c => c.Name == "GetStarted");
                    TaxForm t = new TaxForm();
                    t.UserID = User.Claims.First().Value;
                    t.TaxYear = selectedyear;
                    t.isFiled = false;
                    t.Person = _db.Person.First(c => c.UserId == User.Claims.First().Value);
                    t.Filingstatus = f;
                    t.FilingStatus = "GetStarted";
                    t.FilingStatusID = f.Id;
                    _db.Add(t);
                    _db.SaveChanges();
                    return RedirectToAction(nameof(Create), new { id = t.ID, status = "GetStarted" });
                }
                else {
                    var t = _db.TaxForms.First(c => c.TaxYear == selectedyear && c.UserID == User.Claims.First().Value);
                    return RedirectToAction(nameof(Create), new { id = t.ID, status = "Continue" });
                }
                return RedirectToAction(nameof(Index));
            }
            catch(Exception )
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult CreateDependednt(Dependent model)
        {            
                return PartialView("~/view/shared/DependentForm.cshtml");            
        }

        // GET: TaxFormController1/Edit/5
        public ActionResult Edit(int id)
        {
            TaxFormViewModel tfvm = new TaxFormViewModel();
            tfvm.Init(_db);
            return View(tfvm.GetTaxById(id));
        }

        // POST: TaxFormController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TaxForm model)
        {
            TaxFormViewModel tfvm = new TaxFormViewModel();
            tfvm.Init(_db);
            var editTaxForm = tfvm.GetTaxById(id);
            editTaxForm.TaxYear = model.TaxYear;
            _db.Update<TaxForm>(editTaxForm);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Delete(int id)
        {
            TaxFormViewModel tfvm = new TaxFormViewModel();
            tfvm.Init(_db);
            _db.TaxForms.Remove(tfvm.GetTaxById(id));
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
