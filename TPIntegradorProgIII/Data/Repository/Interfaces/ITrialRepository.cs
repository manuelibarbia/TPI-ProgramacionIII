using TPIntegradorProgIII.Entities;

namespace TPIntegradorProgIII.Data.Repository.Interfaces
{
    public interface ITrialRepository
    {
        public Trial? GetOneTrial(int id);
        public List<Trial> GetAllTrial();
        public void AddTrial(Trial trial);
        public void DeleteTrial(int id);
    }
}
