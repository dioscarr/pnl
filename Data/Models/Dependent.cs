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
        public int TaxFormID { get; set; }
        [ForeignKey("TaxFormID")]
        public virtual TaxForm TaxForm { get; set; }
        [Required(ErrorMessage = "first name is required")]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:###-##-####}")]
        public string SSN { get; set; }
        [Required]
        public int MonthInHome { get; set; }
        [Required]
        public string RelationshipName { get; set; }
        [Required]
        public string Code { get; set; }
        public string isUsCitizen { get; set; } = "no";
        public string ResidentUSCanadaMexicolastyear { get; set; } = "no";
        public string SingleorMarriedAsOf { get; set; } = "no";
        public string FullTimeStudentLastYear { get; set; } = "no";
        public string TotallyPermanentlyDisabled { get; set; } = "yes";
        public bool Selected { get; set; } 
    }
}
