using Castle.DynamicProxy.Contributors;
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

        public void SaveAndReview(int TaxFormId)
        {
            var taxform = _db.TaxForms.Find(TaxFormId);
            taxform.isFiled = true;
            _db.SaveChanges();
        }
        public bool UpdateCurrentUser(Person model)
        {
            try
            {
                var userID = _httpContextAccessor.HttpContext.User.Claims.First().Value;
                var existingUser = _db.Person.FirstOrDefault(c => c.UserId == userID);
                existingUser.FirstName = model.FirstName;
                existingUser.LastName = model.LastName;
                existingUser.SSN = model.SSN;
                existingUser.MiddleName = model.MiddleName;
                existingUser.Occupation = model.Occupation;
                existingUser.Email = model.Email;
                existingUser.Birthday = model.Birthday;
                existingUser.Phone = model.Phone;
                existingUser.UserId = userID;
                _db.Update(existingUser);
                _db.SaveChanges(); 
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }
        public (List<int>, List<TaxForm>) GetTaxYears(int NumberOfPreviousYears = 20) {

            var userID = _httpContextAccessor.HttpContext.User.Claims.First().Value;
            List<int> taxyears = new List<int>();
            for (int yearIndex = 0; yearIndex < NumberOfPreviousYears; yearIndex++)
            {
                taxyears.Add(DateTime.UtcNow.AddYears(-yearIndex).Year);
            }                      
            var TaxApplications = _db.TaxForms.Where(c => c.UserID == userID).ToList();
            return (taxyears, TaxApplications);
        }
        public Person SaveTaxFormCurrentUserInfo(Person model, int TaxFormID)
        {
            var dataModel = new TaxFormPerson
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                SSN = model.SSN,
                MiddleName = model.MiddleName,
                Occupation = model.Occupation,
                Email = model.Email,
                Birthday = model.Birthday,
                Phone = model.Phone,
                TaxFormID = TaxFormID
            };
            if (_db.TaxFormPeople.Any(c => c.TaxFormID == TaxFormID)){
                var existingModel = _db.TaxFormPeople.First(c => c.TaxFormID == TaxFormID);
                existingModel.FirstName = model.FirstName;
                existingModel.LastName = model.LastName;
                existingModel.SSN = model.SSN;
                existingModel.MiddleName = model.MiddleName;
                existingModel.Occupation = model.Occupation;
                existingModel.Email = model.Email;
                existingModel.Birthday = model.Birthday;
                existingModel.Phone = model.Phone;
                existingModel.TaxFormID = TaxFormID;
                _db.Update(dataModel);
            }
            else { 
                _db.TaxFormPeople.Add(dataModel);
            }
            _db.SaveChanges();
            return model;
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
        public TaxForm GetTaxForm(int TaxFormID)
        {
            return _db.TaxForms.Find(TaxFormID);
        }
        public Person GetCurrentUser(int TaxFormID)
        {
            var userID = _httpContextAccessor.HttpContext.User.Claims.First().Value;
            if (_db.TaxFormPeople.Any(c => c.TaxFormID == TaxFormID))
            {
                return _db.TaxFormPeople.Where(c => c.TaxFormID == TaxFormID).Select(c=> new Person { 
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    SSN = c.SSN,
                    MiddleName = c.MiddleName,
                    Occupation = c.Occupation,
                    Email = c.Email,
                    Birthday = c.Birthday,
                    Phone = c.Phone                     
                }).First();
            }
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
        public DependentCareProviders GetCareProviderIfExist(int TaxFormID)
        {
            var dc = _db.DependentCare.FirstOrDefault(c => c.TaxFormID == TaxFormID);
            if (dc==null)
            {
                return new DependentCareProviders();
            }
                return dc;
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
        public List<ToggleMe> GetCriteriaOptions(){
            return _db.CriteriaOption.Select(c => new ToggleMe { name = c.Name, isToggled = false }).ToList();
        }
        public List<TaxFormCriteria> GetTaxFormCriteria(int TaxFormId)
        {
            return _db.TaxFormCriteria.Where(c => c.TaxFormID == TaxFormId).ToList();
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
        
    }
}
