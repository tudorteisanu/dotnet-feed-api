using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace feedApi.Auth.dto
{
	public class LoginResponseDto
	{
        public String token { get; set; }

        public LoginResponseDto(String token)
        {
            this.token = token;
        }
    }
}

