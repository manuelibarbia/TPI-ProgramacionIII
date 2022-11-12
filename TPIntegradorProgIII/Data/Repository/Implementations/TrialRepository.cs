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

        public List<Trial> GetAllTrial() 
        {
            return _context.Trials.ToList();
        }

        void ITrialRepository.AddTrial(Trial trial)
        {
            throw new NotImplementedException();
        }

        void ITrialRepository.DeleteTrial(int id)
        {
            throw new NotImplementedException();
        }

        
        Trial? ITrialRepository.GetOneTrial(int id)
        {
            throw new NotImplementedException();
        }
    }
}