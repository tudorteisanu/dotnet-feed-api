using System.ComponentModel.DataAnnotations;

namespace feedApi.Auth.dto
{
    public class  RegisterRequestDto
    {
        [Required]
        [EmailAddress]
        public String Email { set; get; }


        [Required]
        [MinLength(2), MaxLength(128)]
        public String FirstName { set; get; }



        [Required]
        [MinLength(2), MaxLength(128)]
        public String LastName { set; get; }

        [Required]
        [MinLength(8), MaxLength(128)]
        public String Password { set; get; }
    }
}

