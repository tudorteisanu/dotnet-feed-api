using System.ComponentModel.DataAnnotations;

namespace feedApi.User.dto
{
	public class UserResponseDto
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Email { get; set; }
    }
}

