using TPIntegradorProgIII.Entities;


namespace TPIntegradorProgIII.Data.Repository
{
   
    public interface IMeetRepository
    {
        public Meet? GetSingleMeet(int id);
        public List<Meet> GetMeets();
        public void AddMeet(Meet newMeet);
        public void RemoveMeet(int id);
        public void EditMeetDate(int id, string newMeetDate);
        public List<Trial> GetTrials(int id);
    }
}
