using System;
using System.ComponentModel.DataAnnotations;

namespace feedApi.Auth.dto
{
    public class  LoginRequestDto
    {
        [Required]
        [EmailAddress]
        public String email { set; get; }

        [Required]
        [MinLength(8), MaxLength(256)]
        public String password { set; get; }
    }
}

