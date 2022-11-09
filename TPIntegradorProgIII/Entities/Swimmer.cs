namespace TPIntegradorProgIII.Entities
{
    public class Swimmer : User
    {
        public ICollection<Meet> MeetsAttended { get; set; } = new List<Meet>();
        public ICollection<Trial> TrialsAttended { get; set; } = new List<Trial>();
    }
}
