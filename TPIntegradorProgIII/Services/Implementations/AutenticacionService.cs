using TPIntegradorProgIII.Data.Repository.Interfaces;
using TPIntegradorProgIII.Entities;
using TPIntegradorProgIII.Models;
using TPIntegradorProgIII.Services.Interfaces;

namespace TPIntegradorProgIII.Services.Implementations
{
    public class AutenticacionService : ICustomAuthenticationService
    {
        private readonly IUserRepository _userRepository;

        public AutenticacionService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        public User? ValidateUser(AuthenticationRequestBody authenticationRequest)
        {
            if (string.IsNullOrEmpty(authenticationRequest.Email) || string.IsNullOrEmpty(authenticationRequest.Password))
                return null;
            return _userRepository.ValidateUser(authenticationRequest);
        }
    }
}
