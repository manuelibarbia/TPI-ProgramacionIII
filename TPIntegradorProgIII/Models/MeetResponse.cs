using TPIntegradorProgIII.Entities;

namespace TPIntegradorProgIII.Models
{
    public class MeetResponse
    {
        public int Id { get; set; }
        public string MeetName { get; set; }
        public string MeetDate { get; set; }
        public string MeetPlace { get; set; }
        public ICollection<Trial> Trials { get; set; } = new List<Trial>();
    }
}
