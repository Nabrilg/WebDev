using System;
using System.Collections.Generic;
using System.Text;

namespace WebDev.Services.Entities
{
    public class UpdatedUserDto
    {
        public int id { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        private UpdatedUserDto()
        {

        }

        public static UpdatedUserDto Build(int id, string email, string name, string username, string password)
        {
            return new UpdatedUserDto
            {
                id = id,
                email = email,
                name = name,
                username = username,
                password = password
            };
        }
    }
}
