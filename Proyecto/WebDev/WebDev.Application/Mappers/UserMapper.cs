
using WebDev.Application.Models;
using WebDev.Services.Entities;

namespace WebDev.Application.Mappers
{
    public class UserMapper
    {
        public CreateUserDto MapUserToCreateUserDto(User user)
        {
            return CreateUserDto.Build(
                id: user.Id,
                email: user.Email,
                name: user.Name,
                username: user.Username,
                password: user.Password
            );
        }

        public UpdateUserDto MapUserToUpdateUserDto(User user)
        {
            return UpdateUserDto.Build(
                id: user.Id,
                email: user.Email,
                name: user.Name,
                username: user.Username,
                password: user.Password
            );
        }

        public User MapUserDtoToUser(UserDto userDto)
        {
            return new User
            {
                Id = userDto.Id,
                Email = userDto.Email,
                Name = userDto.Name,
                Username = userDto.Username,
                Password = userDto.Password
            };
        }
    }
}
