using TPIntegradorProgIII.Data.Repository.Interfaces;
using TPIntegradorProgIII.Entities;
using TPIntegradorProgIII.Models;
using TPIntegradorProgIII.Services.Interfaces;

namespace TPIntegradorProgIII.Services.Implementations
{
    public class AutenticacionService : ICustomAuthenticationService
    {
        private readonly ISwimmerRepository _swimmerRepository;

        public AutenticacionService(ISwimmerRepository swimmerRepository)
        {
            _swimmerRepository = swimmerRepository;
        }
        
        public Swimmer? ValidateSwimmer(AuthenticationRequestBody authenticationRequest)
        {
            if (string.IsNullOrEmpty(authenticationRequest.UserName) || string.IsNullOrEmpty(authenticationRequest.Password))
                return null;
            return _swimmerRepository.ValidateSwimmer(authenticationRequest);
        }
    }
}
