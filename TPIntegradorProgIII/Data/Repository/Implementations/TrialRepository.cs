using TPIntegradorProgIII.Data.Repository.Interfaces;
using TPIntegradorProgIII.Entities;
using TPIntegradorProgIII.Models;
using TPIntegradorProgIII.DBContexts;
using TPIntegradorProgIII.Data.Repository;

namespace TPIntegradorProgIII.Data.Repository
{
    public class TrialRepository : TPRepository, ITrialRepository
    {
        public TrialRepository(TPContext context) : base(context)
        {
        }
    }
}