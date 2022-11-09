using System.ComponentModel.DataAnnotations;

namespace TPIntegradorProgIII.Models
{
	public class AuthenticationRequestBody
	{
        [Required]
		public string? Email { get; set; }
        [Required]
		public string? Password { get; set; }
		public string UserType { get; set; } //¿Para qué sirve? ¿Lo necesitamos?
	}
}

