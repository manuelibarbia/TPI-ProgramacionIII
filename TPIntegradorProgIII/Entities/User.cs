using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TPIntegradorProgIII.Helpers;

namespace TPIntegradorProgIII.Entities
{
    public class User
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        private string _Password;
        public string Password {
            get { return _Password; }
            set { _Password = Security.CreateSHA512(value);}
        }
        public string UserType { get; set; } // ¿Para qué sirve? ¿Lo necesitamos?
    }
}
