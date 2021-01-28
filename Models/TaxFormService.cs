using Castle.DynamicProxy.Contributors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using pnl.Data;
using pnl.Data.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace pnl.Models
{
    public class TaxFormService
    {
        private readonly ApplicationDbContext _db;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IWebHostEnvironment _env;
        public TaxFormService(ApplicationDbContext db, IHttpContextAccessor httpContextAccessor, IWebHostEnvironment env)
        {
            _db = db;
            _httpContextAccessor = httpContextAccessor;
            _env = env;
        }
        public void GetSummary(int id)
        { 
            
        }
        public void SaveProgressStep2(int TaxFormId, int Step, Step2VM CurrentStep)
        {
            try
            {
                var updatePrimary = _db.TaxFormPeople.FirstOrDefault(c => c.TaxFormID == TaxFormId && c.isSpouse == false);
                if (updatePrimary != null)
                {
                    updatePrimary.Birthday = CurrentStep.CurrentUserInfo.Birthday;
                    updatePrimary.Email = CurrentStep.CurrentUserInfo.Email;
                    updatePrimary.FirstName = CurrentStep.CurrentUserInfo.FirstName;
                    updatePrimary.LastName = CurrentStep.CurrentUserInfo.LastName;
                    updatePrimary.MiddleName = CurrentStep.CurrentUserInfo.MiddleName;
                    updatePrimary.Occupation = CurrentStep.CurrentUserInfo.Occupation;
                    updatePrimary.Phone = CurrentStep.CurrentUserInfo.Phone;
                    updatePrimary.SSN = CurrentStep.CurrentUserInfo.SSN;
                    
                }
                else
                {
                    _db.TaxFormPeople.Add(new TaxFormPerson
                    {
                        Birthday = CurrentStep.CurrentUserInfo.Birthday,
                        Email = CurrentStep.CurrentUserInfo.Email,
                        FirstName = CurrentStep.CurrentUserInfo.FirstName,
                        LastName = CurrentStep.CurrentUserInfo.LastName,
                        MiddleName = CurrentStep.CurrentUserInfo.MiddleName,
                        Occupation = CurrentStep.CurrentUserInfo.Occupation,
                        Phone = CurrentStep.CurrentUserInfo.Phone,
                        SSN = CurrentStep.CurrentUserInfo.SSN,
                        TaxFormID = TaxFormId,
                        UserId = CurrentStep.CurrentUserInfo.UserId,
                        isSpouse = false
                    });
                }
                _db.SaveChanges();

                var updateSpouse = _db.TaxFormPeople.FirstOrDefault(c => c.TaxFormID == TaxFormId && c.isSpouse == true);
                if (updateSpouse!=null)
                {
                    updateSpouse.Birthday = CurrentStep.Spouse.Birthday;
                    updateSpouse.Email = CurrentStep.Spouse.Email;
                    updateSpouse.FirstName = CurrentStep.Spouse.FirstName;
                    updateSpouse.LastName = CurrentStep.Spouse.LastName;
                    updateSpouse.MiddleName = CurrentStep.Spouse.MiddleName;
                    updateSpouse.Occupation = CurrentStep.Spouse.Occupation;
                    updateSpouse.Phone = CurrentStep.Spouse.Phone;
                    updateSpouse.SSN = CurrentStep.Spouse.SSN;
                }
                else
                { 
                    _db.TaxFormPeople.Add(new TaxFormPerson {
                    Birthday = CurrentStep.Spouse.Birthday,
                    Email = CurrentStep.Spouse.Email,
                    FirstName = CurrentStep.Spouse.FirstName,                
                    LastName = CurrentStep.Spouse.LastName,
                    MiddleName = CurrentStep.Spouse.MiddleName,
                    Occupation = CurrentStep.Spouse.Occupation,
                    Phone = CurrentStep.Spouse.Phone,   
                    SSN = CurrentStep.Spouse.SSN,
                    TaxFormID = TaxFormId,
                    UserId = CurrentStep.CurrentUserInfo.UserId,
                    isSpouse = true
                    });
                }
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                throw;
            }
        }
        public void SaveProgressStep3(List<Answer> answers)
        {
            try
            {
                var add = answers.Where(c => c.Id == 0).ToList();
                var update = answers.Where(c => c.Id > 0).ToList();
                if(add.Count() > 0)
                    _db.AddRange(add); 
                if (update.Count() > 0) 
                    _db.UpdateRange(update);
                _db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

        }
        public List<Question> GetQuestions(int FormStepId)
        {
            try
            {
                return _db.Questions.Where(c => c.FormStepId == FormStepId).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Answer> GetAnswers(int taxFormId, int stepnumber)
        {
            try
            {
                return _db.Answers.Include(c=>c.Question).Where(c => c.TaxFormId == taxFormId && c.Question.FormStep.TheStep == stepnumber).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<FormStep> GetFormStep(int TheStep)
        {
            try
            {
                return _db.FormSteps.Include(c=>c.Questions).Where(c => c.TheStep == TheStep).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<state> GetStates()
        {            
            var stateJsonPath = $"{_env.ContentRootPath}/Data/states.json";
            List<state> items = new List<state>();
            using (StreamReader r = new StreamReader(stateJsonPath))
            {
                string json = r.ReadToEnd();
                items = JsonConvert.DeserializeObject<List<state>>(json);
            }
            return items;
        }
        public (List<int>, List<TaxForm>) GetTaxYears(int NumberOfPreviousYears = 20) {

            var userID = _httpContextAccessor.HttpContext.User.Claims.First().Value;
            List<int> taxyears = new List<int>();
            for (int yearIndex = 0; yearIndex < NumberOfPreviousYears; yearIndex++)
            {
                taxyears.Add(DateTime.UtcNow.AddYears(-yearIndex).Year);
            }
            taxyears.Add(DateTime.UtcNow.AddYears(1).Year);
            var TaxApplications = _db.TaxForms.Where(c => c.UserID == userID && c.isFiled == false).ToList();
            return (taxyears, TaxApplications);
        }
        public (List<int>, List<TaxForm>, List<TaxForm>) GetTaxYearsAndArchived(int NumberOfPreviousYears = 20)
        {

            var userID = _httpContextAccessor.HttpContext.User.Claims.First().Value;
            List<int> taxyears = new List<int>();
            for (int yearIndex = 0; yearIndex < NumberOfPreviousYears; yearIndex++)
            {
                taxyears.Add(DateTime.UtcNow.AddYears(-yearIndex).Year);
            }
            var TaxApplications = _db.TaxForms.Where(c => c.UserID == userID && c.isFiled == false).ToList();
            var TaxFormArchived = _db.TaxForms.Where(c => c.UserID == userID && c.isFiled == true).ToList();
            return (taxyears, TaxApplications, TaxFormArchived);
        }
        public TaxForm GetTaxForm(int TaxFormID)
        {
            return _db.TaxForms.Find(TaxFormID);
        }
        public Person GetCurrentUser(int TaxFormID)
        {
            //var userID = _httpContextAccessor.HttpContext.User.Claims.First().Value;
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
            return _db.TaxForms.First(c => c.ID == TaxFormID).Person;
        }
        public Address GetCurrentUserAddress(int taxFormId)
        {
            // var userID = _httpContextAccessor.HttpContext.User.Claims.First().Value;
            var p = _db.TaxForms.First(c => c.ID == taxFormId).Person.Address;
            if (p != null){
                return p;
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
            var userID = _httpContextAccessor.HttpContext.User.Claims.First().Value;
            return await _db.TaxForms.Where(c => c.TaxYear == TaxYear && c.UserID == userID).FirstOrDefaultAsync();
        }
        public (int,string) CheckIfCurrentTaxYearExist()
        {
            var currentYear = DateTime.Now.Year;
             var result =  _db.TaxForms.Where(c => c.TaxYear == currentYear).FirstOrDefault();
            if (result != null)
            {
                return (result.ID,result.FilingStatus);
            }
            
            TaxForm t = new TaxForm();
            var userID = _httpContextAccessor.HttpContext.User.Claims.First().Value;
            t.TaxYear = DateTime.Now.Year;
            t.FilingStatus = "GetStarted";
            t.UserID = userID;
            t.Person = _db.Person.First(c => c.UserId == userID);
            t.Filingstatus = _db.FilingStatus.First(c=>c.Name == "GetStarted");
            _db.TaxForms.Add(t);
            _db.SaveChanges();
            return (t.ID, "GetStarted");
        }
        public async Task<Dependent> AddDependentAsync(Dependent model)
        {
            if (model != null && model.TaxFormID > 0)
            {
                try
                {
                    model.SSN= "";
                    model.Code = ""; //from original form needs to be removed
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
        public async Task<TaxForm> CreateNewTaxFormAsync(int TaxYear)
        {
            try
            {                   
                var Anyexisting = _db.TaxForms.Any(c => c.TaxYear == TaxYear && c.isFiled ==false);   
                if(Anyexisting)
                    return _db.TaxForms.First(c => c.TaxYear == TaxYear && c.isFiled == false);
                
                TaxForm t = new TaxForm();
                var userID = _httpContextAccessor.HttpContext.User.Claims.First().Value;
                t.TaxYear = TaxYear;
                t.FilingStatus = "Continue";
                t.UserID = userID;
                t.Person = _db.Person.Where(c=>c.UserId == userID).First();
                t.FilingStatusID = _db.FilingStatus.First(c => c.Name == "GetStarted").Id;
                _db.TaxForms.Add(t);
                await _db.SaveChangesAsync();
                return t;
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public async Task<List<ToggleMe>> SaveSelectedCriteriasAsync(List<ToggleMe> model, int TaxFormId)
        {
            List<TaxFormCriteria> tfc = new List<TaxFormCriteria>();
            var criterias = await _db.CriteriaOption.ToListAsync();
            foreach (var item in model.Where(c=>c.isToggled==true).ToList()){

                tfc.Add(new TaxFormCriteria { TaxFormID = TaxFormId, Name = item.name });
            }
            if (tfc.Count() > 0){
                if (tfc.Count() > 0)
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
        public bool SubmitTaxForm(int taxFormId)
        {
            try
            {
                if (taxFormId > 0)
                {
                    var taxform = _db.TaxForms.Find(taxFormId);
                    if (_db.Answers.Any(c=>c.TaxFormId == taxFormId))
                    {
                        taxform.FilingStatus = "Continue";
                        taxform.FilingStatusID = _db.FilingStatus.First(c => c.Name == "Continue").Id;
                    }
                    else { 
                        taxform.FilingStatus = "GetStarted";
                        taxform.FilingStatusID = _db.FilingStatus.First(c => c.Name == "GetStarted").Id;
                    }
                    taxform.isFiled = true;
                    taxform.CreatedOn = DateTime.Now;
                    taxform.UpdatedOn= DateTime.Now;

                    _db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        public void SaveAndReview(int TaxFormId)
        {
            var taxform = _db.TaxForms.Find(TaxFormId);
            taxform.isFiled = true;
            _db.SaveChanges();
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
        public List<Dependent> DeleteDependents(List<Dependent> model, int TaxFormId)
        {
            try
            {
            if (model.Count() > 0)
                    _db.RemoveRange(model);
            _db.SaveChanges();
                return _db.Dependent.Where(c => c.TaxFormID == TaxFormId).ToList();
            }
            catch (Exception e)
            {

                throw;
            }
        }
        public ReportData GetReport(int taxFormId)
        {
            ReportData rd = new ReportData(_db);
           var report = rd.GetReport(taxFormId);
            return report;
        }
    }
}
