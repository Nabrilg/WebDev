using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebDev.Application.Models
{
    public class Login
    {
        [Required (ErrorMessage="El Email es Requerido")]
        [EmailAddress]
        public string email { get; set; }

        [Required(ErrorMessage = "El Password es Requerido")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        //[Display(Name = "Remember me?")]
        //public bool RememberMe { get; set; }
    }

}
