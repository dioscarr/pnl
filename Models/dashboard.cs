using pnl.Data;
using pnl.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pnl.Models
{
    public class dashboard
    {
        
        public Person CurrentUser { get; set; }
        public  List<TaxForm>PreviousTaxes{ get; set; }
        public TaxForm ContinueTaxes { get; set; }
        ApplicationDbContext _db;
        public dashboard(ApplicationDbContext db)
        {
            _db = db;
        }
        public void init(string UserId)
        {
            CurrentUser = new Person();
            PreviousTaxes = new List<TaxForm>();
            ContinueTaxes = new TaxForm();

            PreviousTaxes = _db.TaxForms.Where(c => c.Person.UserId == UserId && c.isFiled == true).ToList();
            ContinueTaxes = _db.TaxForms.Where(c => c.Person.UserId == UserId && c.isFiled == false)
                .OrderByDescending(c => c.TaxYear).FirstOrDefault();

            CurrentUser = _db.Person.Where(c => c.UserId == UserId).Select(c => new Person
            {
                FirstName = c.FirstName,
                LastName = c.LastName,
                SSN = c.SSN,
                MiddleName = c.MiddleName,
                Occupation = c.Occupation,
                Email = c.Email,
                Birthday = c.Birthday,
                Phone = c.Phone
            }).FirstOrDefault();


        }
    }
}
