using TPIntegradorProgIII.Entities;

namespace TPIntegradorProgIII.Models
{
    public class TrialResponse
    {
        public int Id { get; set; }
        public int Distance { get; set; }
        public string Style { get; set; }
        public string MeetName { get; set; }

        public List<string> RegisteredSwimmers { get; set; } = new List<string>();
    }
}
