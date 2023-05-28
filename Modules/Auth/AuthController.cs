using feedApi.Auth.dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace feedApi.Auth
{
    [Route("auth")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAuthService authService;

        public LoginController(IAuthService authService)
        {
            this.authService = authService;
        }

        [AllowAnonymous]
        [HttpPost("login", Name = "Login")]
        public ActionResult<LoginResponseDto> Login([FromBody] LoginRequestDto userLogin)
        {
            return this.authService.Login(userLogin);
        }

        [AllowAnonymous]
        [HttpPost("register", Name = "Registration")]
        public ActionResult<LoginResponseDto> Register([FromBody] RegisterRequestDto userLogin)
        {
            return this.authService.Register(userLogin);
        }

    }

}