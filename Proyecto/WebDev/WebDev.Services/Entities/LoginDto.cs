using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebDev.Services.Entities
{
    public class LoginDto
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        private LoginDto()
        {

        }

        public static LoginDto Build(string email, string password)
        {
            return new LoginDto
            {
                Email = email,
                Password = password
            };
        }

    }
}
