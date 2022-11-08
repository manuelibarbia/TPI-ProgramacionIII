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
        public string UserName { get; set; }
        [Required]
        private string _Password;
        public string Password {
            get { return _Password; }
            set { _Password = Security.CreateSHA512(value);}
        }
        public DateTime BirthDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
