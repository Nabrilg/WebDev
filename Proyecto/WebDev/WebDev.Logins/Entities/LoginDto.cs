﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WebDev.Logins.Entities
{
    public class LoginDto
    {
        public string email { get; set; }
        public string password { get; set; }

        private LoginDto()
        {
        }

        public static LoginDto Build(string email, string password)
        {
            return new LoginDto
            {
                email = email,
                password = password
            };
        }
    }
}