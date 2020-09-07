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

        public TaxFormViewModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<TaxForm> TaxForms{ get; set; }
        public void LoadFiledTaxesByUserID(string UserID) {
            TaxForms = _db.TaxtForms.Where(c => c.UserID == UserID).ToList();            
        }

        internal TaxForm GetTaxById(int id)
        {
            return _db.TaxtForms.Find(id);
        }
    }
}
