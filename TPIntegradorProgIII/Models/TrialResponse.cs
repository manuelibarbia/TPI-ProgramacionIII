using TPIntegradorProgIII.Entities;

namespace TPIntegradorProgIII.Models
{
    public class TrialResponse
    {
        public int Id { get; set; }
        public int Distance { get; set; }
        public string Style { get; set; }
        public string MeetName { get; set; }
        public int MeetId { get; set; }

        public List<Swimmer> RegisteredSwimmers { get; set; } = new List<Swimmer>();
    }
}
