using TPIntegradorProgIII.Entities;
using TPIntegradorProgIII.Helpers;

public interface IUserRepository
{
    public User? Get(int id);
    public List<User> GetAll();
    public void Add(User user);
    public User? ValidateUser(AuthenticationRequestBody user);
   
}

public User ValidateUser(AuthenticationRequestBody dto)
{
    return FakeUsers.SingleOrDefault(u => u.UserName == dto.UserName && u.Password == Security.CreateSHA512(dto.Password));
}