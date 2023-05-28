using System;
using System.ComponentModel.DataAnnotations;

namespace feedApi.Users.dto
{
    public class CreateUserDto
    {
        [Required]
        [StringLength(128, MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(128, MinimumLength = 3)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(128, MinimumLength = 3)]
        public string Email { get; set; }

        [Required]
        [StringLength(256, MinimumLength = 3)]
        public string Password { get; set; }
    }
}

