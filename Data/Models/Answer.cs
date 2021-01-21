
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace pnl.Data.Models
{
    public class Answer
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }        
        
        public string TheAnswer { get; set; }
        public DateTime AnsweredOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        
        [Required]
        [ForeignKey("TaxForm")]
        public int TaxFormId { get; set; }

        [Required]
        [ForeignKey("Question")]
        public int QuestionId { get; set; }
        public virtual TaxForm TaxForm { get; set; }
        public virtual Question Question { get; set; }
    }
}
