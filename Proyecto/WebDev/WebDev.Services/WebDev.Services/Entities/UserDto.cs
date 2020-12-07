namespace WebDev.Services.Entities
{
    public class UserDto
    {
        public string email { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public int id { get; set; }

        private UserDto()
        {
        }

        public static UserDto Build(string email, string name, string username, string password, int id)
        {
            return new UserDto
            {
                email = email,
                name = name,
                username = username,
                password = password,
                id = id
            };
        }
    }
}