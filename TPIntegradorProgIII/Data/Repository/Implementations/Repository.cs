using TPIntegradorProgIII.Data.Repository.Interfaces;

namespace TPIntegradorProgIII.Data.Repository.Implementations
{
    public class Repository : IRepository
    {
        internal readonly StudentsQuestionsContext _context;

        public Repository(StudentsQuestionsContext context)
        {
            this._context = context;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
