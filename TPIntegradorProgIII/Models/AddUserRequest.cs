using System.ComponentModel.DataAnnotations;

namespace TPIntegradorProgIII.Models
{
    public class AddUserRequest
    {
        [MaxLength(10)]
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
