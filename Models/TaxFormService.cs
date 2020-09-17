using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using pnl.Data;
using pnl.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pnl.Models
{
    public class TaxFormService
    {
        private readonly ApplicationDbContext _db;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public TaxFormService(ApplicationDbContext db, IHttpContextAccessor httpContextAccessor)
        {
            _db = db;
            _httpContextAccessor = httpContextAccessor;
        }

        public DependentCareProviders GetCareProviderIfExist(int TaxFormID)
        {
            var dc = _db.DependentCare.FirstOrDefault(c => c.TaxFormID == TaxFormID);
            if (dc==null)
            {
                return new DependentCareProviders();
            }
                return dc;
        }

        public DependentCareProviders SaveCareProvider(DependentCareProviders model)
        {
            if (_db.DependentCare.Any(c => c.TaxFormID == model.TaxFormID))
            {
                model.id = _db.DependentCare.First(c => c.TaxFormID == model.TaxFormID).id;
                _db.Update(model);
                _db.SaveChanges();               
            }
            else
            {
                _db.Add(model);
                _db.SaveChanges();
            }
            return model;
        }


        public TaxForm GetTaxForm(int TaxFormID)
        {
            return _db.TaxForms.Find(TaxFormID);
        }
        public (List<int>, List<TaxForm>) GetTaxYears() {

            var userID = _httpContextAccessor.HttpContext.User.Claims.First().Value;
            List<int> taxyears = new List<int>();
            var PreviousYear = DateTime.UtcNow.AddYears(-1).Year;
            var CurrentYear = DateTime.UtcNow.Year;
            var NextYear = DateTime.UtcNow.AddYears(1).Year;
            taxyears.Add(PreviousYear);
            taxyears.Add(CurrentYear);
            taxyears.Add(NextYear);
            var TaxApplications = _db.TaxForms.Where(c => c.UserID == userID).ToList();
            return (taxyears, TaxApplications);
        }
        public async Task<TaxForm> CheckIfTaxExist(int TaxYear)
        {
            return await _db.TaxForms.Where(c => c.TaxYear == TaxYear).FirstOrDefaultAsync();
        }
        public async Task<Dependent> AddDependentAsync(Dependent model)
        {
            if (model != null && model.TaxFormID > 0)
            {
                try
                {
                _db.Add(model);
                await _db.SaveChangesAsync();

                }
                catch (Exception e){
                    throw;
                }
            }
            return model;
        }
        public List<FilingStatus> GetfilingStatuses()
        {
            return _db.FilingStatus.ToList();
        }
        public async Task<TaxForm> CreateNewTaxFormAsync(int TaxYear, int FilingStatusID)
        {
            try
            {
                var filinfstatus = _db.FilingStatus.FirstOrDefault(c => c.Id == FilingStatusID);
                var Anyexisting = _db.TaxForms.Any(c => c.TaxYear == TaxYear);
                if (Anyexisting)
                {
                    var existing = _db.TaxForms.Where(c => c.TaxYear == TaxYear).FirstOrDefault();
                    if (filinfstatus != null && existing.FilingStatusID != FilingStatusID)
                    {
                        existing.FilingStatus = filinfstatus.Name;
                        existing.FilingStatusID = FilingStatusID;
                        _db.Update(existing);
                        await _db.SaveChangesAsync();
                        
                    }
                    return existing;
                }                

                TaxForm t = new TaxForm();
                var userID = _httpContextAccessor.HttpContext.User.Claims.First().Value;
                t.TaxYear = TaxYear;
                t.FilingStatus = filinfstatus.Name;
                t.UserID = userID;
                t.Person = _db.Person.Where(c=>c.UserId == userID).First();
                t.Filingstatus = filinfstatus;
                _db.TaxForms.Add(t);
                await _db.SaveChangesAsync();
                return t;
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public Person GetCurrentUser()
        {
            var userID = _httpContextAccessor.HttpContext.User.Claims.First().Value;
            return _db.Person.Where(c => c.UserId == userID).First();
        }
        public Address GetCurrentUserAddress()
        {
            var userID = _httpContextAccessor.HttpContext.User.Claims.First().Value;
           var p = _db.Person.Where(c => c.UserId == userID).First();
            if (p.Address != null){
                return p.Address;
            }
            else {
                return new Address();
            }
        }
        public List<Dependent> GetDependets(int TaxFormID)
        {
            List<Dependent> Dependents = new List<Dependent>();
            try{
                if (TaxFormID > 0){
                    Dependents =  _db.Dependent.Where(c => c.TaxFormID == TaxFormID).ToList();
                }
            }
            catch (Exception){
                throw;
            }
            return Dependents;
        }
        public List<Dependent> DeleteDependents(List<Dependent> model, int TaxFormId)
        {
            try
            {
            _db.RemoveRange(model);
            _db.SaveChanges();
                return _db.Dependent.Where(c => c.TaxFormID == TaxFormId).ToList();
            }
            catch (Exception e)
            {

                throw;
            }
        }
        public List<ToggleMe> GetCriteriaOptions(){
            return _db.CriteriaOption.Select(c => new ToggleMe { name = c.Name, isToggled = false }).ToList();
        }
        public async Task<List<ToggleMe>> SaveSelectedCriteriasAsync(List<ToggleMe> model, int TaxFormId)
        {
            List<TaxFormCriteria> tfc = new List<TaxFormCriteria>();
            var criterias = await _db.CriteriaOption.ToListAsync();
            foreach (var item in model.Where(c=>c.isToggled==true).ToList()){

                tfc.Add(new TaxFormCriteria { TaxFormID = TaxFormId, Name = item.name });
            }
            if (tfc.Count() > 0){
                _db.AddRange(tfc);
                await _db.SaveChangesAsync();
            }
            return model;
        }
        public List<TaxFormCriteria> GetTaxFormCriteria(int TaxFormId)
        {
            return _db.TaxFormCriteria.Where(c => c.TaxFormID == TaxFormId).ToList();
        }
        
    }
}
