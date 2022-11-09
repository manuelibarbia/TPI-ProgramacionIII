﻿namespace TPIntegradorProgIII.Models
{
    public class MeetDto
    {
        public int MeetID { get; set; }
        public string MeetName { get; set; }
        public string MeetDate { get; set; }
        public string MeetPlace { get; set; }

        public ICollection<SwimmerDto> ParticipantSwimmers { get; set; } = new List<SwimmerDto>();
    }
}
