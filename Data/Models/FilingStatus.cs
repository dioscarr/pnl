using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pnl.Data.Models
{
    public class FilingStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool isEnabled { get; set; }
        public virtual ICollection<TaxForm> TaxForm { get; set; }
    }
}
