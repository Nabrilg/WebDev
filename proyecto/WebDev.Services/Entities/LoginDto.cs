using System;
using System.Collections.Generic;
using System.Text;

namespace WebDev.Services.Entities
{
    public class LoginDto
    {
        #region Atributos
        public string email { get; set; }
        public string password { get; set; }
        #endregion

        #region Constructores
        public LoginDto() { }
        #endregion

        #region Building
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
