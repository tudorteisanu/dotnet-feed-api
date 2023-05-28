using System;
using feedApi.Auth.dto;

namespace feedApi.Auth
{
	public interface IAuthService
	{
        public LoginResponseDto Login(LoginRequestDto userLogin);

        public LoginResponseDto Register(RegisterRequestDto userLogin);
    }
}

