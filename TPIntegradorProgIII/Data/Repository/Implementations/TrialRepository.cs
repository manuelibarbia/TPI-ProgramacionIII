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
    }
}