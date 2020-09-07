using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace pnl.Data.Models
{
    public class TaxForm
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public string UserID { get; set; }
        [Required]
        public int TaxYear { get; set; }
        public string FilingStatus { get; set; }


        [Required]
        [ForeignKey("Person")]
        public int PersonID { get; set; }
        public virtual Person Person { get; set; }

        public virtual ICollection<TaxFormCriteria> TaxFormCriterias { get; set; }
        public virtual ICollection<Dependent> DependentsClaimed { get; set; }
        public virtual ICollection<DependentCareProviders> DependentCareProviders { get; set; }
    }
}
