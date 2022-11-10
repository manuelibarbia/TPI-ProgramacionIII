using TPIntegradorProgIII.Entities;

namespace TPIntegradorProgIII.Models
{
    public class TrialDto
    {
        public int Id { get; set; }
        public int Distance { get; set; }
        public string Style { get; set; }

        public ICollection<Swimmer> RegisteredSwimmers { get; set; } = new List<Swimmer>();
    }
}
