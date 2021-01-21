using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace pnl.Data.Models
{
    public class FormStep
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int TheStep { get; set; }
        public string StepName { get; set; }
        public string SectionName { get; set; }
        public int Section { get; set; }        
        public bool isEnabled { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool isDeleated { get; set; }
        public string ModifiedBy { get; set; }

        public virtual ICollection<Question> Questions{ set; get; }
    }
}
