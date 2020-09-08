using pnl.Data;
using pnl.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pnl.Models
{
    public class TaxFormViewModel
    {
        private ApplicationDbContext _db;

        public TaxFormViewModel()
        {
            
        }
        public void Init(ApplicationDbContext db)
        {
            _db = db;
            CurrentTaxForms = new TaxForm();
            CurrentUser = new Person();
            Address = new Address();
            CriteriaOptions = new List<CriteriaOption>();
        }

        public List<TaxForm> TaxForms{ get; set; }
        public TaxForm CurrentTaxForms { get; set; }
        public Person CurrentUser { get; set; }
        public Address Address { get; set; }
        public List<CriteriaOption> CriteriaOptions { get; set; }
        public void LoadFiledTaxesByUserID(string UserID) {
            TaxForms = _db.TaxtForms.Where(c => c.UserID == UserID).ToList();            
        }
        public void FileNewTaxes(string userid)
        {
            CurrentUser = _db.Person.First(c => c.UserId == userid);
            Address = (CurrentUser.Address != null) ? CurrentUser.Address.First() : new Address();
            CriteriaOptions = _db.CriteriaOption.ToList();
        }
        internal TaxForm GetTaxById(int id)
        {
            return _db.TaxtForms.Find(id);
        }
    }
}
