using TPIntegradorProgIII.Data.Repository.Interfaces;
using TPIntegradorProgIII.DBContexts;
using TPIntegradorProgIII.Entities;
using TPIntegradorProgIII.Helpers;
using TPIntegradorProgIII.Models;

namespace TPIntegradorProgIII.Data.Repository.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly TPContext _context;
        public UserRepository(TPContext context)
        {
            _context = context;
        }

        public User? GetOne(int id)
        {
            try
            {
                return _context.Users.First(x => x.Id == id);
            }
            catch
            {
                throw new Exception("Usuario no encontrado");
            }
        }

        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public void Add(User user)
        {
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
            }
            catch
            {
                throw new Exception("Error al añadir usuario, chequear parámetros");
            }
        }

        public void Delete(int id)
        {
            try
            {
                _context.Users.Remove(_context.Users.First(x => x.Id == id));
                _context.SaveChanges();
            }
            catch
            {
                throw new Exception("Usuario no encontrado");
            }
        }

        public void Edit(int id, string newEmail)
        {
            try
            {
                _context.Users.First(x => x.Id == id).Email = newEmail;
            }
            catch
            {
                throw new Exception("Usuario no encontrado, o los parámetros no son válidos");
            }
        }

        public User? ValidateUser(AuthenticationRequestBody dto)
        {
            var HashPassword = Security.CreateSHA512(dto.Password);
            return _context.Users.SingleOrDefault(u => u.UserName == dto.UserName && u.Password == Security.CreateSHA512(dto.Password));
        }
    }
}
