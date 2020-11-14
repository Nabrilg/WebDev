
namespace WebDev.Services.Entities
{
    public class UserDto
    {
        #region Properties
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        #endregion

        #region Initialize
        private UserDto()
        {

        }

        public static UserDto Build(int id, string email, string name, string username, string password)
        {
            return new UserDto
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
