using TPIntegradorProgIII.Data.Repository.Interfaces;
using TPIntegradorProgIII.Entities;
using TPIntegradorProgIII.Models;
using TPIntegradorProgIII.DBContexts;
using TPIntegradorProgIII.Data.Repository;

namespace TPIntegradorProgIII.Data.Repository
{
    public class MeetRepository : TPRepository, IMeetRepository
    {
        public MeetRepository(TPContext context) : base(context)
        {
        }


    }
}
