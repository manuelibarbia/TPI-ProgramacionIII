using TPIntegradorProgIII.Data.Repository.Interfaces;
using TPIntegradorProgIII.DBContexts;
using TPIntegradorProgIII.Entities;
using TPIntegradorProgIII.Helpers;
using TPIntegradorProgIII.Models;

namespace TPIntegradorProgIII.Data.Repository.Implementations
{
    public class SwimmerRepository : ISwimmerRepository
    {
        private readonly TPContext _context;
        public SwimmerRepository(TPContext context)
        {
            _context = context;
        }

        public Swimmer? GetSingleSwimmer(int id)
        {
            try
            {
                return _context.Swimmers.First(x => x.Id == id);
            }
            catch
            {
                throw new Exception("Nadador no encontrado");
            }
        }

        public List<Swimmer> GetSwimmers()
        {
            return _context.Swimmers.ToList();
        }

        public void AddSwimmer(Swimmer swimmer)
        {
            try
            {
                _context.Swimmers.Add(swimmer);
                _context.SaveChanges();
            }
            catch
            {
                throw new Exception("Error al añadir nadador");
            }
        }

        public void RemoveSwimmer(int id)
        {
            try
            {
                _context.Swimmers.Remove(_context.Swimmers.First(x => x.Id == id));
                _context.SaveChanges();
            }
            catch
            {
                throw new Exception("Nadador no encontrado");
            }
        }

        public void EditSwimmerName(int id, string newName)
        {
            try
            {
                    _context.Swimmers.First(x => x.Id == id).Name = newName;
                    _context.SaveChanges();
            }
            catch
            {
                throw new Exception("Nadador no encontrado o parámetros no válidos");
            }
        }
        public void EditSwimmerSurname(int id, string newSurname)
        {
            try
            {
                _context.Swimmers.First(x => x.Id == id).Surname = newSurname;
                _context.SaveChanges();
            }
            catch
            {
                throw new Exception("Nadador no encontrado o parámetros no válidos");
            }
        }

        public Swimmer? ValidateSwimmer(AuthenticationRequestBody dto)
        {
            var HashPassword = Security.CreateSHA512(dto.Password);
            return _context.Swimmers.SingleOrDefault(u => u.UserName == dto.UserName && u.Password == Security.CreateSHA512(dto.Password));
        }

        public List<Trial> GetExistingTrials()
        {
            return _context.Trials.ToList();
        }

        public string GetAttendedTrial(int id)
        {
            var style = _context.Trials.First(t => t.Id == id).Style;
            var distance = _context.Trials.First(t => t.Id == id).Distance;
            var meetName = _context.Trials.First(t => t.Id == id).MeetName;

            var attendedTrial = style + " " + distance + " metros" + " (" + meetName + ")";
            return attendedTrial;
        }
    }
}
