namespace TPIntegradorProgIII.Entities
{
    public class SwimmersTrials
    {
        public int SwimmerId { get; set; }
        public int TrialId { get; set; }
        public Swimmer Swimmer { get; set; }
        public Trial Trial { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Valor { get; set; }

        public List<SwimmersTrials> RegisteredSwimmersId { get; set; } = new List<SwimmersTrials>();
        public List<SwimmersTrials> TrialsAttendedId { get; set; } = new List<SwimmersTrials>();
    }
}
