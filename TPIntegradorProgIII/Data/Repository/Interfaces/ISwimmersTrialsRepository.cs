using TPIntegradorProgIII.Entities;

namespace TPIntegradorProgIII.Data.Repository.Interfaces
{
    public interface ISwimmersTrialsRepository
    {
        public void AddSwimmerToTrial(int swimmerId, int trialId);
        public List<Swimmer> GetExistingSwimmers();
        public List<Trial> GetExistingTrials();
    }
}
