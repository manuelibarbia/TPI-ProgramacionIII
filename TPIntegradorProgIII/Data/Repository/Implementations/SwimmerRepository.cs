using TPIntegradorProgIII.Data.Repository.Interfaces;
using TPIntegradorProgIII.Entities;
using TPIntegradorProgIII.Models;
using TPIntegradorProgIII.DBContexts;
using TPIntegradorProgIII.Data.Repository;
using Microsoft.EntityFrameworkCore;

namespace TPIntegradorProgIII.Data.Repository
{
    public class SwimmerRepository : TPRepository, ISwimmerRepository
    {
        public SwimmerRepository(TPContext context) : base(context)
        {
        }

        //public ICollection<Meet> GetSwimmerMeets(int swimmerId) =>  // ¿Falta trials? O ya está en GetSwimmerMeets
        //    _context.Swimmers.Include(a => a.MeetsAttended).ThenInclude(m => m.Trials).Where(a => a.Id == swimmerId)
        //    .Select(a => a.MeetsAttended).FirstOrDefault() ?? new List<Meet>();
        public Swimmer? GetSwimmerById(int userId) => _context.Swimmers.Find(userId);

        public ICollection<Trial> GetSwimmerTrials(int swimmerId)
        {
            throw new NotImplementedException();
        }
    }
}
