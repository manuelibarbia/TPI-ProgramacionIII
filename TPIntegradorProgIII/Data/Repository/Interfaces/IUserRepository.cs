using TPIntegradorProgIII.Entities;
using TPIntegradorProgIII.Models;

namespace TPIntegradorProgIII.Data.Repository.Interfaces
{
    public interface IUserRepository
    {
        public User? GetSingleUser(int id);
        public List<User> GetUsers();
        public void AddUser(User user);
        public void RemoveUser(int id);
        public void EditName(int id, string newName);
        public void EditSurname(int id, string surname);
        public User? ValidateUser(AuthenticationRequestBody user);
    }
}
