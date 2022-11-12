namespace TPIntegradorProgIII.Entities
{
    public class Swimmer : User
    {
        public ICollection<Trial> TrialsAttended { get; set; } = new List<Trial>();
    }
}
