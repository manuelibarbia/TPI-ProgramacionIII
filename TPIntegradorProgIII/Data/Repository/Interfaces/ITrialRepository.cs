using TPIntegradorProgIII.Entities;

namespace TPIntegradorProgIII.Data.Repository.Interfaces
{
    public interface ITrialRepository
    {
        public Trial? GetSingleTrial(int id);
        public List<Trial> GetTrials();
        public void AddTrial(Trial trial);
        public void RemoveTrial(int id);
        public void EditTrialDistance(int id, int newDistance);
        public void EditTrialStyle(int id, string newStyle);
        public List<Meet> GetExistingMeets();
        public List<Swimmer> GetRegisteredSwimmers(int id);
        public Meet GetTrialMeet(int id);
        public string GetTrialMeetName(int id);
        //public List<Meet> GetSingleMeet(int id);
    }
}
