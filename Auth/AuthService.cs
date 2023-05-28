using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using feedApi.Auth.dto;
using feedApi.Shared.Services.Jwt;
using feedApi.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace feedApi.Auth
{

    public class AuthService : IAuthService
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public AuthService(IMapper mapper, IUserService userService)
        {
            this.userService = userService;
            this.mapper = mapper;
        }

        public LoginResponseDto Login(LoginRequestDto userLogin)
        {
            var user = Authenticate(userLogin);
            var token = GenerateToken(user);

            return new LoginResponseDto(token);
        }

        public LoginResponseDto Register(RegisterRequestDto payload)
        {
            var userMap = this.mapper.Map<User>(payload);
            var user = this.userService.Create(userMap);
            var token = GenerateToken(user);

            return new LoginResponseDto(token);
        }

        // To generate token
        private string GenerateToken(User user)
        {
            var claims = new[]
            {
                new Claim("FirstName", user.FirstName),
                new Claim("LastName", user.LastName),
                new Claim("id", user.id.ToString()),
                new Claim("email", user.Email)
            };


            return JwtService.GenerateToken(
                claims,
                DateTime.Now.AddMinutes(15));
        }

        //To authenticate user
        private User Authenticate(LoginRequestDto userLogin)
        {
            var user = this.userService.FindByEmail(userLogin.email);
            if (user is null)
            {
                throw new Exception("user not found");
            }


            var isValidPassword = BCrypt.Net.BCrypt.Verify(userLogin.password, user.Password);

            if (isValidPassword)
            {
                throw new Exception("Invalid Credentials");
            }

            return user;
        }

    }

}