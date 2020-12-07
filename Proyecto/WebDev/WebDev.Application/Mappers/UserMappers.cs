using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebDev.Services.Entities;
using WebDev.Application.Models;

namespace WebDev.Application.Mappers
{
    public class UserMappers
    {
        public static User MapperToUser(UserDto userDto)
        {
            return new User
            {
                Id = userDto.id,
                Email = userDto.email,
                Name = userDto.name,
                Username = userDto.username,
                Password = userDto.password
            };
        }

        public static UserDto MapperToUserDto(User user)
        {
            return UserDto.Build(
              id: user.Id,
              email: user.Email,
              name: user.Name,
              username: user.Username,
              password: user.Password
            );
        }
    }
}
