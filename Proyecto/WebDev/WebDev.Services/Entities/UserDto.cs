using System;
using System.Collections.Generic;
using System.Text;

namespace WebDev.Services.Entities
{
    public class UserDto
    {
        public int Id { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        private UserDto()
        {

        }

        public static UserDto Build( int id, string _email, string _name, string _username, string _password)
        {
            return new UserDto
            {
                Id = id,
                email = _email,
                name = _name,
                username = _username,
                password = _password
            };
        }

    }
}