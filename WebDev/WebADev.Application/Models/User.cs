using System.ComponentModel.DataAnnotations;

namespace WebDev.Application.Models
{
    public class User
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "El email es obligatorio")]
        public string email { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string name { get; set; }
        [Required(ErrorMessage = "El nombre de usuario es obligatorio")]
        public string username { get; set; }
        [Required(ErrorMessage = "El password es obligatorio")]
        public string password { get; set; }
    }
}