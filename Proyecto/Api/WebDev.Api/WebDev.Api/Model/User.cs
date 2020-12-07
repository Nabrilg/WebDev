using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebDev.Api.Model
{
    using System.ComponentModel.DataAnnotations;
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Email { get; set; }
        [Required]
        public int Name { get; set; }
        [Required]
        public int Password { get; set; }
        [Required]
        public int Username { get; set; }
    }
}
