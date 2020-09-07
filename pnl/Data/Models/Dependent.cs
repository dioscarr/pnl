using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace pnl.Data.Models
{
    public class Dependent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        [ForeignKey("TaxForm")]
        public int TaxFormID { get; set; }
        public virtual TaxForm TaxForm { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string SSN { get; set; }
        public int MonthInHome { get; set; }
        public string RelationshipName { get; set; }
        public string Code { get; set; }
    }
}
