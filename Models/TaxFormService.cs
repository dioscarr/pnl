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
        public async Task<TaxForm> CreateNewTaxFormAsync(int TaxYear, string FilingStatus ="")
        {
            try
            {
                var existing = _db.TaxtForms.Where(c => c.TaxYear == TaxYear).FirstOrDefault();
                if (existing != null)
                    return existing;

                TaxForm t = new TaxForm();
                var userID = _httpContextAccessor.HttpContext.User.Claims.First().Value;
                t.TaxYear = TaxYear;
                t.FilingStatus = FilingStatus;
                t.UserID = userID;
                t.Person = _db.Person.Where(c=>c.UserId == userID).First();                
                _db.TaxtForms.Add(t);
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
                return p.Address.First();
            }
            else {
                return new Address();
            }
        }
        public List<Dependent> GetDependets(int TaxFormID)
        {
            List<Dependent> Dependents = new List<Dependent>();
            try
            {
                if (TaxFormID > 0)
                {
                    Dependents =  _db.Dependent.Where(c => c.TaxFormID == TaxFormID).ToList();
                }
            }
            catch (Exception){
                throw;
            }
            return Dependents;
        }
    }
}
