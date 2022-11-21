using TPIntegradorProgIII.Entities;
using TPIntegradorProgIII.Models;

namespace TPIntegradorProgIII.Data.Repository.Interfaces
{
    public interface ISwimmerRepository
    {
        public Swimmer? GetSingleSwimmer(int id);
        public List<Swimmer> GetSwimmers();
        public void AddSwimmer(Swimmer swimmer);
        public void RemoveSwimmer(int id);
        public void EditSwimmerName(int id, string newName);
        public void EditSwimmerSurname(int id, string surname);
        public Swimmer? ValidateSwimmer(AuthenticationRequestBody swimmer);
        List<Trial> GetExistingTrials();
        public string GetAttendedTrial(int id);
    }
}
