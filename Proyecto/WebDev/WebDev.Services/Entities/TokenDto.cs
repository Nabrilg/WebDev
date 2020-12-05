using Newtonsoft.Json;

namespace WebDev.Services.Entities
{
    public class TokenDto
    {
        #region Properties
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
        #endregion

        #region Initialize
        private TokenDto()
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
        #endregion
    }
}
