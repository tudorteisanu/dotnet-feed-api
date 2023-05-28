using System;
using System.ComponentModel.DataAnnotations;

namespace feedapi.Auth.dto
{
    public class  LoginRequestDto
    {
        [Required]
        [EmailAddress]
        [MinLength(8)]
        public String email { set; get; }

        [Required]
        public String password { set; get; }
    }
}

