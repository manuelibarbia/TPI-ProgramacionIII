using TPIntegradorProgIII.Data.Repository.Interfaces;
using TPIntegradorProgIII.Entities;
using TPIntegradorProgIII.Helpers;
using TPIntegradorProgIII.Models;

namespace TPIntegradorProgIII.Data.Repository.Implementations
{
    public class UserRepository : IUserRepository
    {
        private List<User> FakeUsers = new List<User>()
        {
            new User()
            {
                Id = 0,
                UserName = "First",
                Password = "password"
            }
        };

        public User? Get(int id)
        {
            return FakeUsers.FirstOrDefault(u => u.Id == id);
        }

        public List<User> GetAll()
        {
            return FakeUsers;
        }

        public void Add(User user)
        {
            FakeUsers.Add(user);
        }

        public User? ValidateUser(AuthenticationRequestBody dto)
        {
            return FakeUsers.SingleOrDefault(u => u.UserName == dto.UserName && u.Password == Security.CreateSHA512(dto.Password));
        }
    }
}
