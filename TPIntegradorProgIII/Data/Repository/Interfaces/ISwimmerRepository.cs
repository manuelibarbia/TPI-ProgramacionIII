using TPIntegradorProgIII.Entities;

namespace TPIntegradorProgIII.Data.Repository.Interfaces
{
    public interface ISwimmerRepository
    {
        Swimmer? GetSwimmerById(int userId);
    }
}
