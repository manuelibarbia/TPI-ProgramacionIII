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
        public void ModifyName(int id, string newName);
        public void ModifySurname(int id, string surname);
        public User? ValidateUser(AuthenticationRequestBody user);
    }
}
