using pnl.Data;
using pnl.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pnl.Models
{
    public class TaxFormViewModel : ITaxFormViewModel
    {
        private ApplicationDbContext _db;

        public TaxFormViewModel()
        {

        }
        public void Init(ApplicationDbContext db)
        {
            _db = db;
            CurrentTaxForm = new TaxForm();
            CurrentUser = new Person();
            Address = new Address();
            CriteriaOptions = new List<CriteriaOption>();
            Dependent = new Dependent();
        }

        public List<TaxForm> TaxForms { get; set; }
        public TaxForm CurrentTaxForm { get; set; }
        public Person CurrentUser { get; set; }
        public Address Address { get; set; }
        public List<ToggleMe> HOptions { get; set; }
        public List<CriteriaOption> CriteriaOptions { get; set; }
        public Dependent Dependent { get; set; }
        public List<int> years { get; set; }
        internal void LoadTaxYears(string usrId)
        {
                years = new List<int>();
                int NumberOfPreviousYears = 20;
                var userID = usrId;
                for (int yearIndex = 0; yearIndex < NumberOfPreviousYears; yearIndex++)
                {
                    years.Add(DateTime.UtcNow.AddYears(-yearIndex).Year);
                }
        }
        public void LoadFiledTaxesByUserID(string UserID)
        {
            TaxForms = _db.TaxForms.Where(c => c.UserID == UserID).ToList();
        }
        public void FileNewTaxes(string userid)
        {
            CurrentUser = _db.Person.First(c => c.UserId == userid);
            Address = (CurrentUser.Address != null) ? CurrentUser.Address : new Address();
            CriteriaOptions = _db.CriteriaOption.ToList();

            HOptions = CriteriaOptions.Select(c => new ToggleMe { name = c.Name, isToggled = false }).ToList();
        }
        internal TaxForm GetTaxById(int id)
        {
            return _db.TaxForms.Find(id);  
        }
    }
}
