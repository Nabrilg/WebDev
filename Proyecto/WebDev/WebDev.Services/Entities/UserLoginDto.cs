using System;
using System.Collections.Generic;
using System.Text;

namespace WebDev.Services.Entities
{
    public class UserLoginDto
    {
        public string email { get; set; }
        public string password { get; set; }

        public UserLoginDto()
        {

        }

        public static UserLoginDto Build(string _email,string _password)
        {
            return new UserLoginDto
            {
                email = _email,
                password = _password
            };
        }

    }
}

