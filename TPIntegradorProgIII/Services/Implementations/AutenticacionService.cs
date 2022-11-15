using TPIntegradorProgIII.Data.Repository.Interfaces;
using TPIntegradorProgIII.Entities;
using TPIntegradorProgIII.Models;
using TPIntegradorProgIII.Services.Interfaces;

namespace TPIntegradorProgIII.Services.Implementations
{
    public class AutenticacionService : ICustomAuthenticationService
    {
        private readonly ISwimmerRepository _userRepository;

        public AutenticacionService(ISwimmerRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        public Swimmer? ValidateUser(AuthenticationRequestBody authenticationRequest)
        {
            if (string.IsNullOrEmpty(authenticationRequest.UserName) || string.IsNullOrEmpty(authenticationRequest.Password))
                return null;
            return _userRepository.ValidateUser(authenticationRequest);
        }
    }
}
