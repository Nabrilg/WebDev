
namespace WebDev.Services.Entities
{
    public class IdResponseDto
    {
        #region Properties
        public long id { get; set; }
        #endregion

        #region Initialize
        public IdResponseDto() { }

        public static IdResponseDto Build(long id)
        {
            return new IdResponseDto()
            {
                id = id
            };
        }
        #endregion
    }
}
