using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace pnl.Data.Models
{
    public class TaxFormPerson
    {
        

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public  string UserId { get; set; }
        [Required(ErrorMessage ="")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "")]
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "")]
        public string Phone { get; set; }
        public string Email { get; set; }
        [Required(ErrorMessage = "")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Birthday { get; set; }
        [Required(ErrorMessage = "")]
        public string SSN { get; set; }
        [Required(ErrorMessage = "")]
        public string Occupation { get; set; }              

        [Required]
        public int TaxFormID { get; set; }
        [ForeignKey("TaxFormID")]
        public virtual TaxForm TaxForms { get; set; }
    }
}
