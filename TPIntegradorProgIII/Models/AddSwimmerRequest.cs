﻿using System.ComponentModel.DataAnnotations;

namespace TPIntegradorProgIII.Models
{
    public class AddSwimmerRequest
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int DNI { get; set; }
        public int TrialId { get; set; }
    }
}
