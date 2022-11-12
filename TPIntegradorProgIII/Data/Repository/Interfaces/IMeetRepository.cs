using TPIntegradorProgIII.Entities;


namespace TPIntegradorProgIII.Data.Repository
{
   
    public interface IMeetRepository
    {
        public Meet? GetOneMeet(int id);
        public List<Meet> GetAllMeets();
        public void AddMeet(Meet meet);
        public void DeleteMeet(int id);
    }
}
