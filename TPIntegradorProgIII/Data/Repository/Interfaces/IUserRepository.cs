using TPIntegradorProgIII.Entities;
using TPIntegradorProgIII.Models;

namespace TPIntegradorProgIII.Data.Repository.Interfaces
{
    public interface IUserRepository
    {
        public User? Get(int id);
        public List<User> GetAll();
        public void Add(User user);
        public User? ValidateUser(AuthenticationRequestBody user);
    }
}
