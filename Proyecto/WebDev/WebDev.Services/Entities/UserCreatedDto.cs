namespace WebDev.Services.Entities
{
    public class CreateUserDto
    {
        public string email { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        private CreateUserDto()
        {

        }

        public static CreateUserDto Build(string email, string name, string username, string password)
        {
            return new CreateUserDto
            {
                email = email,
                name = name,
                username = username,
                password = password
            };
        }

    }
}