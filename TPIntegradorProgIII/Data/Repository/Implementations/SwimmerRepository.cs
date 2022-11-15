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

        public Swimmer? GetSingleUser(int id)
        {
            try
            {
                return _context.Swimmers.First(x => x.Id == id);
            }
            catch
            {
                throw new Exception("Usuario no encontrado");
            }
        }

        public List<Swimmer> GetUsers()
        {
            return _context.Swimmers.ToList();
        }

        public void AddUser(Swimmer user)
        {
            try
            {
                _context.Swimmers.Add(user);
                _context.SaveChanges();
            }
            catch
            {
                throw new Exception("Error al añadir usuario");
            }
        }

        public void RemoveUser(int id)
        {
            try
            {
                _context.Swimmers.Remove(_context.Swimmers.First(x => x.Id == id));
                _context.SaveChanges();
            }
            catch
            {
                throw new Exception("Usuario no encontrado");
            }
        }

        public void EditName(int id, string newName)
        {
            try
            {
                    _context.Swimmers.First(x => x.Id == id).Name = newName;
                    _context.SaveChanges();
            }
            catch
            {
                throw new Exception("Usuario no encontrado o parámetros no válidos");
            }
        }
        public void EditSurname(int id, string newSurname)
        {
            try
            {
                _context.Swimmers.First(x => x.Id == id).Surname = newSurname;
                _context.SaveChanges();
            }
            catch
            {
                throw new Exception("Usuario no encontrado o parámetros no válidos");
            }
        }

        public Swimmer? ValidateUser(AuthenticationRequestBody dto)
        {
            var HashPassword = Security.CreateSHA512(dto.Password);
            return _context.Swimmers.SingleOrDefault(u => u.UserName == dto.UserName && u.Password == Security.CreateSHA512(dto.Password));
        }
    }
}
