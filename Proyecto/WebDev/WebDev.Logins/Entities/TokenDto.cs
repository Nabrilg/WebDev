namespace WebDev.Logins.Entities
{
    public class TokenDto
    {
        public string token { get; set; }
        public string userId { get; set; }
        public string name { get; set; }

        private TokenDto()
        {
        }

        public static TokenDto Build(string token, string userId, string name)
        {
            return new TokenDto
            {
                token = token,
                userId = userId,
                name = name
            };
        }
    }
}