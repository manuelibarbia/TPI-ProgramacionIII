using TPIntegradorProgIII.Entities;


namespace TPIntegradorProgIII.Data.Repository
{
   
    public interface IMeetRepository
    {
        public Meet? GetSingleMeet(int id);
        public List<Meet> GetAllMeets();
        public void AddMeet(Meet meet);
        public void DeleteMeet(int id);
        public void ModifyMeetDate(int id, string newMeetDate);
    }
}
