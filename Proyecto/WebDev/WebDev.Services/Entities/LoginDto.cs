
namespace WebDev.Services.Entities
{
    public class LoginDto
    {
        #region Properties
        public string email { get; set; }
        public string password { get; set; }
        #endregion

        #region Initialize
        private LoginDto()
        {

        }

        public static LoginDto Build(string email, string password)
        {
            return new LoginDto
            {
                email = email,
                password = password
            };
        }
        #endregion
    }
}
