using System.IdentityModel.Tokens.Jwt;
using System.Text;
using feedapi.Auth.dto;
using feedApi.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace JWTAuth
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IUserService userService;

        public LoginController(IConfiguration config, IUserService userService)
        {
            _config = config;
            this.userService = userService;
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login([FromBody] LoginRequestDto userLogin)
        {
            var user = Authenticate(userLogin);

            if (user is null)
            {
                return NotFound("user not found");
            }


            //var isValidPassword = BCrypt.Net.BCrypt.Verify(userLogin.password, user.Password);

            if (userLogin.password != user.Password)
            {
                return Unauthorized("Invalid Credentials");
            }

            var token = GenerateToken(user);
            return Ok(new LoginResponseDto(token));
        }

        // To generate token
        private string GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(token);

        }

        //To authenticate user
        private User Authenticate(LoginRequestDto userLogin)
        {
            var user = this.userService.FindByEmail(userLogin.email);
            System.Diagnostics.Debug.WriteLine(user);
            return user;
        }

    }

}