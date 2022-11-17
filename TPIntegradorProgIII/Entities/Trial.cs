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
        public int Id { get; set; }
        public int Distance { get; set; }
        public string Style { get; set; }

        public string MeetName { get; set; }

        // Cada trial va a pertenecer a un único meet
        [ForeignKey("MeetId")]
        public Meet Meet { get; set; }
        public int MeetId { get; set; }

        public List<Swimmer> RegisteredSwimmers { get; set; } = new List<Swimmer>();
    }
}
