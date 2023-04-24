using TPIntegradorProgIII.Data.Repository.Interfaces;
using TPIntegradorProgIII.Entities;
using TPIntegradorProgIII.Models;
using TPIntegradorProgIII.DBContexts;
using TPIntegradorProgIII.Data.Repository;

namespace TPIntegradorProgIII.Data.Repository
{
    public class TrialRepository : ITrialRepository
    {
        
        private readonly TPContext _context;
        public TrialRepository(TPContext context)
        {
            _context = context;
        }

        public List<Trial> GetTrials() 
        {
            return _context.Trials.ToList();
        }

        public Trial? GetSingleTrial(int id)
        {
            try
            {
                return _context.Trials.First(x => x.Id == id);
            }
            catch
            {
                throw new Exception("Trial no encontrado");
            }
        }

        public void AddTrial(Trial trial)
        {
            try
            {
                _context.Trials.Add(trial);
                _context.SaveChanges();
            }
            catch
            {
                throw new Exception("Error al crear el trial");
            }
        }

        public void RemoveTrial(int id)
        {
            try
            {
                _context.Trials.Remove(_context.Trials.First(x => x.Id == id));
                _context.SaveChanges();
            }
            catch
            {
                throw new Exception("Trial no encontrado, revisar si el Id es correcto.");
            }
        }

        public void EditTrialDistance(int id, int newDistance)
        {
            try
            {
                _context.Trials.First(t => t.Id == id).Distance = newDistance;
                _context.SaveChanges();
            }
            catch
            {
                throw new Exception("Trial no encontrado, revisar si el Id es correcto");
            }
        }

        public void EditTrialStyle(int id, string newStyle)
        {
            try
            {
                _context.Trials.First(t => t.Id == id).Style = newStyle;
                _context.SaveChanges();
            }
            catch
            {
                throw new Exception("Trial no encontrado, revisar si el Id es correcto");
            }
        }

        public List<Meet> GetExistingMeets()
        {
            return _context.Meets.ToList();
        }

        public List<Swimmer> GetRegisteredSwimmers(int id)
        {
            return _context.Swimmers.Where(s => s.TrialId == id).ToList();
        }

        public Meet GetTrialMeet(int id)
        {
            return _context.Meets.First(m => m.Id == id);
        }

        public string GetTrialMeetName(int id)
        {
            return _context.Meets.First(m => m.Id == id).MeetName;
        }
    }
}