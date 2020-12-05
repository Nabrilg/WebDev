using Newtonsoft.Json;

namespace WebDev.Services.Entities
{
    public class CreateUserDto
    {
        #region Properties
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
        #endregion

        #region Initialize
        private CreateUserDto()
        {

        }

        public static CreateUserDto Build(int id, string email, string name, string username, string password)
        {
            return new CreateUserDto
            {
                Id = id,
                Email = email,
                Name = name,
                Username = username,
                Password = password
            };
        }
        #endregion
    }
}
