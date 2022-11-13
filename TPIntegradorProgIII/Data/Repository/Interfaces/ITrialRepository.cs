using TPIntegradorProgIII.Entities;

namespace TPIntegradorProgIII.Data.Repository.Interfaces
{
    public interface ITrialRepository
    {
        public Trial? GetSingleTrial(int id);
        public List<Trial> GetTrials();
        public void AddTrial(Trial trial);
        public void RemoveTrial(int id);
    }
}
