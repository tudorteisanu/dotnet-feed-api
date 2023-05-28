namespace feedApi.Shared.Services.EncryptionService
{
	public class EncryptionService
	{
       


        public static bool Verify(string password, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }

        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}

