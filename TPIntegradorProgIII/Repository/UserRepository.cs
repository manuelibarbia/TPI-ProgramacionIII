using System;
using TPIntegradorProgIII.Entities;

namespace TPIntegradorProgIII.Repository
{
    public class UserRepository : IUserRepository
    {
        private List<User> FakeUsers = new List<User>();
        {
            new User()
            {
                Id = 0,
                UserName = "First",
                Password = "Password"
            }
        };
    }
        public User? Get(int id);
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

    public User ValidateUser(AuthenticationRequestBody dto)
    {
        return FakeUsers.SingleOrDefault(u => u.UserName == dto.UserName && u.Password == dto.Password);
    }
}