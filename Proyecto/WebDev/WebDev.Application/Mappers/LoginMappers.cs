using WebDev.Application.Models;
using WebDev.Logins.Entities;

namespace WebDev.Application.Mappers
{
    public static class LoginMappers
    {
        public static LoginDto MapperToLoginDto(Login login)
        {
            return LoginDto.Build(
              email: login.Email,
              Password: login.Password
            );
        }

        public static TokenDto MapperToTokenDto(Login token)
        {
            return TokenDto.Build(
                token: token.Token,
                userId: token.UserId,
                name: token.Name
            );
        }
    }
}