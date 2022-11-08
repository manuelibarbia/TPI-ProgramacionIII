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
        public string Style { get; set; }

        public ICollection<Swimmer> RegisteredSwimmers { get; set; } = new List<Swimmer>();

        // Cada trial va a tener un único meet
        [ForeignKey("MeetId")]
        public Meet Meet { get; set; }
        public int MeetId { get; set; }


        //[ForeignKey("UserId")]
        //public User User { get; set; }
        //public int UserId { get; set; }
    }
}
