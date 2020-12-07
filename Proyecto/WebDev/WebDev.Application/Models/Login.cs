using System.ComponentModel.DataAnnotations;

namespace WebDev.Application.Models
{
    public class Login
    {
        [Required(ErrorMessage = "El email es obligatorio")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "El password es obligatorio")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }

        public string Token { get; set; }

        public string UserId { get; set; }
        public string Name { get; set; }
    }
}