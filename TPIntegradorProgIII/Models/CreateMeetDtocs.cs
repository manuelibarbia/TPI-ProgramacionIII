﻿using TPIntegradorProgIII.Entities;



namespace TPIntegradorProgIII.Models
{
    public class CreateMeetDto
    {
        public int Id { get; set; }
        public string MeetName { get; set; }
        public string MeetDate { get; set; }
        public string MeetPlace { get; set; }

      
    }
}