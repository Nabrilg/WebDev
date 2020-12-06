using System;
using System.Collections.Generic;
using System.Text;

namespace WebDev.Services.Entities
{
    public class TokenDto
    {
        public string name { get; set; }
        public string token { get; set; }
        public int userId { get; set; }
        private TokenDto()
        {

        }
        public static TokenDto Build(string name, string token, int id)
        {
            return new TokenDto
            {
                name = name,
                token = token,
                userId = id
            };
        }
    }
}
