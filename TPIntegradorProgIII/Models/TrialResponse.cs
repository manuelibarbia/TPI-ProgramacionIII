using TPIntegradorProgIII.Entities;

namespace TPIntegradorProgIII.Models
{
    public class TrialResponse
    {
        public int Id { get; set; }
        public int Distance { get; set; }
        public string Style { get; set; }
        public int MeetId { get; set; }

        public ICollection<Swimmer> RegisteredSwimmers { get; set; } = new List<Swimmer>();
    }
}
