
using TPIntegradorProgIII.Entities;

using TPIntegradorProgIII.DBContexts;


namespace TPIntegradorProgIII.Data.Repository
{
   


    public class MeetRepository : IMeetRepository
    {
        private readonly TPContext _context;
        public MeetRepository(TPContext context)
        {
            _context = context;
        }

        public Meet? GetOneMeet(int id)
        {
            try
            {
                return _context.Meets.First(x => x.Id == id);
            }
            catch
            {
                throw new Exception("Meet no encontrado");
            }
        }

        public List<Meet> GetAllMeets()
        {
            return _context.Meets.ToList();
        }

        public void AddMeet(Meet meet)
        {
            try
            {
                _context.Meets.Add(meet);
                _context.SaveChanges();
            }
            catch
            {
                throw new Exception("Error al añadir meet");
            }
        }

        public void DeleteMeet(int id)
        {
            try
            {
                _context.Meets.Remove(_context.Meets.First(x => x.Id == id));
                _context.SaveChanges();
            }
            catch
            {
                throw new Exception("Meet no encontrado");
            }
        }


        

    }

}