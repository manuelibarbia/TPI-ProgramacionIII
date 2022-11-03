using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPIntegradorProgIII.Entities
{
    public class Swimmer : User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SwimmerID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public int Document { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }
        public string Birth { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
