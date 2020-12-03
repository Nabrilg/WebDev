
namespace WebDev.Services.Entities
{
    public class TokenDto
    {
        #region Properties
        public string token { get; set; }
        public string userId { get; set; }
        public string name { get; set; }
        #endregion

        #region Initialize
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
        #endregion
    }
}
