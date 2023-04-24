
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

        public Meet? GetSingleMeet(int id)
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

        public List<Meet> GetMeets()
        {
            try
            {
                return _context.Meets.ToList();
            }
            catch
            {
                throw new Exception("No se pudo traer los meets");
            }
        }

        public void AddMeet(Meet newMeet)
        {
            try
            {
                _context.Meets.Add(newMeet);
                _context.SaveChanges();
            }
            catch
            {
                throw new Exception("Error al añadir meet");
            }
        }

        public void RemoveMeet(int id)
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

        public void EditMeetDate(int id, string newMeetDate)
        {
            try
            {
                _context.Meets.First(m => m.Id == id).MeetDate = newMeetDate;
                _context.SaveChanges();
            }
            catch
            {
                throw new Exception("Meet no encontrado o parámetros no válidos");
            }
        }

        public List<Trial> GetTrials(int id)
        {
            return _context.Trials.Where(t => t.MeetId == id).ToList();
        }
   }

}