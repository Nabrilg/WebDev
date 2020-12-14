using System.ComponentModel.DataAnnotations;

namespace WebDev.Application.Models
{
    public class Login
    {
        [Required(ErrorMessage = "¡El email es requerido!")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "¡La clave es requerida!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}