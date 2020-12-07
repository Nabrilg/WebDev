using System;
using System.Collections.Generic;
using System.Text;

namespace WebDev.Services.Entities
{
    public class TokenDto
    {
        #region Atributos
        public string token { get; set; }
        public int userId { get; set; }
        public string name { get; set; }
        #endregion

        #region Constructores
        private TokenDto() { }
        #endregion

        #region Buildings
        public static TokenDto Build(string token, int userId, string name)
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
