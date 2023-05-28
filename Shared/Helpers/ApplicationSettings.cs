using System;
namespace feedApi.Shared.Helpers
{
	public class ApplicationSettings
	{
        public const string Jwt = "Jwt";

        public static JwtOptions JwtOptions { get; set; } = new JwtOptions();
	}

    public class JwtOptions
    {
        public string Key { get; set; }

        public string Audience { get; set; }

        public string Issuer { get; set; }
    }
}

