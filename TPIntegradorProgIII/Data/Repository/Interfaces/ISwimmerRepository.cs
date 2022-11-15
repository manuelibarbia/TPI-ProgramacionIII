using TPIntegradorProgIII.Entities;
using TPIntegradorProgIII.Models;

namespace TPIntegradorProgIII.Data.Repository.Interfaces
{
    public interface ISwimmerRepository
    {
        public Swimmer? GetSingleUser(int id);
        public List<Swimmer> GetUsers();
        public void AddUser(Swimmer user);
        public void RemoveUser(int id);
        public void EditName(int id, string newName);
        public void EditSurname(int id, string surname);
        public Swimmer? ValidateUser(AuthenticationRequestBody user);
    }
}
