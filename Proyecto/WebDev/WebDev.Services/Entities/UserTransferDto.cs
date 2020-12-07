using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace WebDev.Services.Entities
{
    public class UserTransferDto
    {
        public int id { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}
