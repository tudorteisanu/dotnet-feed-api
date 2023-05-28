using System;
using System.ComponentModel.DataAnnotations;

namespace feedApi.Roles.dto
{
	public class UpdateRoleDto
	{
        public string Name { get; set; }

        public string Alias { get; set; }
    }
}

