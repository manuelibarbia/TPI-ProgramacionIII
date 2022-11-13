using TPIntegradorProgIII.Models;

namespace TPIntegradorProgIII.Services.Interfaces
{
    public interface ISwimmerService
    {
        ICollection<TrialResponse> GetTrialsBySwimmer(int swimmerId);
    }
}
