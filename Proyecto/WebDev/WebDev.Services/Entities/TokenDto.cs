using System;
using System.Collections.Generic;
using System.Text;

namespace WebDev.Services.Entities
{
    public class TokenDto
    {
        public string Token { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }

        public TokenDto()
        {

        }

        public static TokenDto Build(string token, int id, string name)
        {
            return new TokenDto
            {
                Token = token,
                Id = id,
                Name = name
            };
        }
    }
}
