using TPIntegradorProgIII.Entities;
using TPIntegradorProgIII.Models;

namespace TPIntegradorProgIII.Data.Repository.Interfaces
{
    public interface IUserRepository
    {
        public User? GetOne(int id);
        public List<User> GetAllUsers();
        public void Add(User user);
        public void Delete(int id);
        public User? ValidateUser(AuthenticationRequestBody user);
    }
}
