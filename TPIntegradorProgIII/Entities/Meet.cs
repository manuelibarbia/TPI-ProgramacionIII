using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPIntegradorProgIII.Entities
{
    public class Meet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MeetID { get; set; }
        [Required]
        public string MeetDate { get; set; }
        [Required]
        public string MeetPlace { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
