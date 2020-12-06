using System.ComponentModel.DataAnnotations;

namespace WebDev.Application.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Email is needed")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is needed")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}