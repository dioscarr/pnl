using pnl.Data.Models;
using System.Collections.Generic;

namespace pnl.Models
{
    public interface ITaxFormViewModel
    {
        Address Address { get; set; }
        List<CriteriaOption> CriteriaOptions { get; set; }
        TaxForm CurrentTaxForm { get; set; }
        Person CurrentUser { get; set; }
        Dependent Dependent { get; set; }
        List<ToggleMe> HOptions { get; set; }
        List<TaxForm> TaxForms { get; set; }
        List<int> years { get; set; }
    }
}