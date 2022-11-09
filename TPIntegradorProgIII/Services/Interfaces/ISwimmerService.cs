using TPIntegradorProgIII.Models;

namespace TPIntegradorProgIII.Services.Interfaces
{
    public interface ISwimmerService
    {
        ICollection<TrialDto> GetTrialsBySwimmer(int swimmerId);
        ICollection<MeetDto> GetMeetsBySwimmer(int swimmerId); // ¿Está correcto? ¿Cómo funciona?
    }
}
