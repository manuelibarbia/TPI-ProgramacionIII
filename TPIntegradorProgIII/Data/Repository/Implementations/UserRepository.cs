using TPIntegradorProgIII.Data.Repository.Interfaces;
using TPIntegradorProgIII.DBContexts;
using TPIntegradorProgIII.Entities;
using TPIntegradorProgIII.Models;

namespace TPIntegradorProgIII.Data.Repository.Implementations
{
    public class UserRepository : TPRepository, IUserRepository
    {
        public UserRepository(TPContext context) : base(context)
        {
        }

        public User? ValidateUser(AuthenticationRequestBody authRequestBody)
        {
            if (authRequestBody.UserType == "swimmer")
                return _context.Swimmers.FirstOrDefault(p => p.Email == authRequestBody.Email && p.Password == authRequestBody.Password);
            return null;
        }

        public User? GetUserById(int userId)
        {
            return _context.Users.Find(userId);
        }
    }
}
