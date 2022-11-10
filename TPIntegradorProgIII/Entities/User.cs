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

        private string _Password;
        public string Password
        {
            get { return _Password; }
            set { _Password = Security.CreateSHA512(value); }
        }


        [Required]
        public string Name { get; set; }
        public string Surname { get; set; }
        [Required]
        public string Email { get; set; }
        public string UserType { get; set; }
    }
}
