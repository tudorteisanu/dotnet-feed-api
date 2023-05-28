using System;
using System.ComponentModel.DataAnnotations;

namespace feedApi.Roles.dto
{
    public class CreateRoleDto
    {
        [Required]
        [StringLength(128, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [StringLength(128, MinimumLength = 3)]
        public string Alias { get; set; }
    }
}

