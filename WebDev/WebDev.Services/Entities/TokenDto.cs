using System;
using System.Collections.Generic;
using System.Text;

namespace WebDev.Services.Entities
{
    public class TokenDto
    {
        #region Atributos
        public string Token { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        #endregion

        #region Constructores
        private TokenDto() { }
        #endregion

        #region Buildings
        public static TokenDto Build(string token, int userId, string name)
        {
            return new TokenDto
            {
                Token = token,
                UserId = userId,
                Name = name
            };
        }
        #endregion
    }
}
