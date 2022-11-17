using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TPIntegradorProgIII.Helpers;

namespace TPIntegradorProgIII.Entities
{
    public class Swimmer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string UserName { get; set; }


        private string _Password;
        public string Password
        {
            get { return _Password; }
            set { _Password = Security.CreateSHA512(value); }
        }

        public string DNI { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string StyleAndDistance { get; set; }

        [ForeignKey("TrialId")]
        public Trial Trial { get; set; }
        public int TrialId { get; set; }
        //public List<Trial> TrialsAttended { get; set; } = new List<Trial>();

        public Swimmer(int id, string userName, string password, string dni, string email, string name, string surname, int trialId)
        {
            Id = id;
            UserName = userName;
            Password = password;
            DNI = dni;
            Email = email;
            Name = name;
            Surname = surname;
            TrialId = trialId;
        }

        public Swimmer()
        {

        }
    }
}
