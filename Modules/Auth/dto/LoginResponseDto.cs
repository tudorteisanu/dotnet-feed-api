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

