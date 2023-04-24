using TPIntegradorProgIII.Entities;
using TPIntegradorProgIII.Models;

namespace TPIntegradorProgIII.Services.Interfaces
{
    public interface ICustomAuthenticationService
    {
        Swimmer? ValidateSwimmer(AuthenticationRequestBody authenticationRequestBody);
    }
}
