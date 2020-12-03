
namespace WebDev.Services.Entities
{
    public class CreateUserDto
    {
        #region Properties
        public int id { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        #endregion

        #region Initialize
        private CreateUserDto()
        {

        }

        public static CreateUserDto Build(int id, string email, string name, string username, string password)
        {
            return new CreateUserDto
            {
                id = id,
                email = email,
                name = name,
                username = username,
                password = password
            };
        }
        #endregion
    }
}
