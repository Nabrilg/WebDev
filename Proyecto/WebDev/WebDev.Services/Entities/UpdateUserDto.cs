
namespace WebDev.Services.Entities
{
    public class UpdateUserDto
    {
        #region Properties
        public string name { get; set; }
        public string username { get; set; }
        #endregion

        #region Initialize
        public UpdateUserDto() { }

        public static UpdateUserDto Build(string name, string username)
        {
            return new UpdateUserDto()
            {
                name = name,
                username = username
            };
        }
        #endregion
    }
}
