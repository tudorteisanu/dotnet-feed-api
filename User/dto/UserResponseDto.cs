using System;
using System.ComponentModel.DataAnnotations;

namespace feedApi.User.dto
{
	public class CreateUserDto
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Email { get; set; }


    }
}

