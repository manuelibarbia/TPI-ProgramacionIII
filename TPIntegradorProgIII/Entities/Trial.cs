using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPIntegradorProgIII.Entities
{
    public class Trial
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TrialID { get; set; }
        [Required]
        public int Distance { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string Style { get; set; }
        List<Trial> Times = new List<Trial>();
    }
}
