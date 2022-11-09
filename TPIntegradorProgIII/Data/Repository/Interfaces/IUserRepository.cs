using TPIntegradorProgIII.Entities;
using TPIntegradorProgIII.Models;

namespace TPIntegradorProgIII.Data.Repository.Interfaces
{
    public interface IUserRepository : ITPRepository
    {
        User? ValidateUser(AuthenticationRequestBody authenticationRequestBody);
        User? GetUserById(int userId);
    }
}
