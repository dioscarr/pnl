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
            tfvm.LoadFiledTaxesByUserID(usrId);
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
        public ActionResult Create()
        {
            var usrId = User.Claims.First().Value;
            TaxFormViewModel tfvm = new TaxFormViewModel();
            tfvm.Init(_db);
            tfvm.FileNewTaxes(usrId);
            return View(tfvm);
        }

        // POST: TaxFormController1/Create
        [HttpPost]
        public ActionResult Create(TaxFormViewModel model, IFormCollection criteria)
        {
            try
            {
                List<TaxFormCriteria> tfc = new List<TaxFormCriteria>();
                var criterias = _db.CriteriaOption.ToList();
                foreach (var item in criterias)
                {
                    var rs = criteria[item.id.ToString()];
                    if (rs.ToString() == "true")
                    {

                        tfc.Add(new TaxFormCriteria { Name = item.Name });
                    }
                }
                model.CurrentTaxForms.TaxFormCriterias = tfc;
                
              var usrId = User.Claims.First().Value;
                model.CurrentTaxForms.UserID = usrId;
                model.CurrentTaxForms.Person = _db.Person.Find(model.CurrentUser.id);
                _db.TaxtForms.Add(model.CurrentTaxForms);
                _db.SaveChanges();
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
            _db.TaxtForms.Remove(tfvm.GetTaxById(id));
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
