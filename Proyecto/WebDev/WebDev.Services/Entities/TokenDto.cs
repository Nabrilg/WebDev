using System;
using System.Collections.Generic;
using System.Text;

namespace WebDev.Services.Entities
{
    public class TokenDto
    {
        public string token { get; set; }
        public int userId { get; set; }

        private TokenDto()
        {

        }

        public static TokenDto Build(string token, int userId)
        {
            return new TokenDto
            {
                token = token,
                userId = userId
            };
        }
    }
}
