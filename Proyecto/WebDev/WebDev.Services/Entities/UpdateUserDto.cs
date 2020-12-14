using Newtonsoft.Json;

namespace WebDev.Services.Entities
{
    public class UpdateUserDto
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
        public UpdateUserDto() { }

        public static UpdateUserDto Build(int id, string email, string name, string username, string password)
        {
            return new UpdateUserDto()
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
