using System;
using System.Collections.Generic;
using System.Text;

namespace WebDev.Services.Entities
{
    public class TokenDto
    {
        public int UserId { get; set; }
        public string Token { get; set; }
        public string Name { get; set; }

        private TokenDto()
        {

        }

        public static TokenDto Build(int userId, string token, string name)
        {
            return new TokenDto
            {
                UserId = userId,
                Name = name,
                Token = token
            };
        }

    }
}
