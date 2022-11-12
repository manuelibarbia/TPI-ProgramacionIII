using TPIntegradorProgIII.Models;

namespace TPIntegradorProgIII.Services.Interfaces
{
    public interface ISwimmerService
    {
        ICollection<TrialDto> GetTrialsBySwimmer(int swimmerId);
    }
}
