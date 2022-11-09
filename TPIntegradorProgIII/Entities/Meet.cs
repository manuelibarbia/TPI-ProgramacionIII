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
        public string MeetName { get; set; }

        [Required]
        public string MeetDate { get; set; }

        [Required]
        public string MeetPlace { get; set; }

        public ICollection<Swimmer> ParticipantSwimmers { get; set; } = new List<Swimmer>();
        public ICollection<Trial> Trials { get; set; } = new List<Trial>();

        //[ForeignKey("UserId")]
        //public User User { get; set; }
        //public int UserId { get; set; }
    }
}
