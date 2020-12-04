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
    }
}
