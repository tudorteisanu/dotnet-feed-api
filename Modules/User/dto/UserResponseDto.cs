using System.ComponentModel.DataAnnotations;

namespace feedApi.Users.dto
{
	public class UserResponseDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
    }
}

