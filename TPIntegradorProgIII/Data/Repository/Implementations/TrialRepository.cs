using TPIntegradorProgIII.Data.Repository.Interfaces;
using TPIntegradorProgIII.Entities;
using TPIntegradorProgIII.Models;
using TPIntegradorProgIII.DBContexts;
using TPIntegradorProgIII.Data.Repository;

namespace TPIntegradorProgIII.Data.Repository
{
    public class TrialRepository : TPRepository, IMeetRepository
    {
        public TrialRepository(TPContext context) : base(context)
        {
        }

        public ICollection<Meet> GetStudentSubjects(int meetId) =>
            _context.Students.Include(a => a.SubjectsAttended).ThenInclude(m => m.Professors).Where(a => a.Id == studentId)
            .Select(a => a.SubjectsAttended).FirstOrDefault() ?? new List<Subject>();
    }
}