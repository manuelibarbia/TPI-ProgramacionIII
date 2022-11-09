namespace TPIntegradorProgIII.Models
{
    public class TrialDto
    {
        public int TrialID { get; set; }
        public int Distance { get; set; }
        public string Style { get; set; }

        public ICollection<SwimmerDto> RegisteredSwimmers { get; set; } = new List<SwimmerDto>();
    }
}
