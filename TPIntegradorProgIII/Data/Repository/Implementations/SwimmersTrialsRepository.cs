using TPIntegradorProgIII.Data.Repository.Interfaces;
using TPIntegradorProgIII.DBContexts;
using TPIntegradorProgIII.Entities;

namespace TPIntegradorProgIII.Data.Repository.Implementations
{
    public class SwimmersTrialsRepository : ISwimmersTrialsRepository
    {
        private readonly TPContext _context;

        public SwimmersTrialsRepository(TPContext context)
        {
            _context = context;
        }
        public void AddSwimmerToTrial(int swimmerId, int trialId)
        {
            try
            {
                
            }
            catch
            {
                throw new Exception("No se pudo añadir el nadador al trial");
            }
        }

        public List<Swimmer> GetExistingSwimmers()
        {
            return _context.Swimmers.ToList();
        }

        public List<Trial> GetExistingTrials()
        {
            return _context.Trials.ToList();
        }
    }
}
