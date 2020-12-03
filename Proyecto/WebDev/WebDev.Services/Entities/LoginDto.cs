using System;
using System.Collections.Generic;
using System.Text;

namespace WebDev.Services.Entities
{
    public class LoginDto
    {
        public string email { get; set; }
        public string password { get; set; }

        public LoginDto()
        {

        }

        public static LoginDto Build(string emailVal, string passwordVal)
        {
            return new LoginDto
            {
                email = emailVal,
                password = passwordVal
            };
        }
    }
}
