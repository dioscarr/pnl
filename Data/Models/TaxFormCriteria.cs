using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace pnl.Data.Models
{
    public class TaxFormCriteria
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; }

        [ForeignKey("TaxForm")]
        [Required]
        public int TaxFormID { get; set; }
        public virtual TaxForm TaxForm { get; set; }
    }
}
