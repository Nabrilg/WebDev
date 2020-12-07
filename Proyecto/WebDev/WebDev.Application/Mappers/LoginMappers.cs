using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebDev.Application.Models;
using WebDev.Logins.Entities;

namespace WebDev.Application.Mappers
{
    public class LoginMappers
    {
        public static LoginDto MapperToLoginDto(Login login)
        {
            return LoginDto.Build(
              email: login.Email,
              password: login.Password
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
