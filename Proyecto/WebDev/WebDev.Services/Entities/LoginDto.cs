using Newtonsoft.Json;

namespace WebDev.Services.Entities
{
    public class LoginDto
    {
        #region Properties
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
        #endregion

        #region Initialize
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
        #endregion
    }
}
