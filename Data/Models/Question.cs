using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace pnl.Data.Models
{
    public class Question
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string TheQuestion { get; set; }
        [Required]
        public int Order { get; set; }
        public bool isEnabled { get; set; }
        public DateTime CreatedAt{ get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool isDeleated { get; set; }
        public string ModifiedBy { get; set; }

        [Required]
        [ForeignKey("AnswerType")]
        public int AnswerTypeId { get; set; }

        [Required]
        [ForeignKey("FormStep")]
        public int FormStepId { get; set; }

        public virtual AnswerType AnswerType { set; get; }
        public virtual FormStep FormStep { set; get; }
    }
}
