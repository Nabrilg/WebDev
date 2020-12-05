using Newtonsoft.Json;

namespace WebDev.Services.Entities
{
    public class IdResponseDto
    {
        #region Properties
        [JsonProperty("id")]
        public long Id { get; set; }
        #endregion

        #region Initialize
        public IdResponseDto() { }

        public static IdResponseDto Build(long id)
        {
            return new IdResponseDto()
            {
                Id = id
            };
        }
        #endregion
    }
}
