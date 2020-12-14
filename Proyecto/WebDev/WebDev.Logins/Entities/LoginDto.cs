namespace WebDev.Logins.Entities
{
    public class LoginDto
    {
        public string email { get; set; }
        public string Password { get; set; }

        private LoginDto()
        {
        }

        public static LoginDto Build(string email, string Password)
        {
            return new LoginDto
            {
                email = email,
                Password = Password
            };
        }
    }
}