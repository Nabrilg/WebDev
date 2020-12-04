using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;


namespace WebDev.Services.Entities
{
    public class TokenDto
    {

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }


        [JsonProperty("name")]
        public string Name { get; set; }

        public TokenDto()
        {

        }

        public static TokenDto Build(string token, string userId, string name)
        {
            return new TokenDto
            {
                Token = token,
                UserId = userId,
                Name = name
            };
        }
    }
}
