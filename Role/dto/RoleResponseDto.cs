using System.ComponentModel.DataAnnotations;

namespace feedApi.Roles.dto
{
	public class RoleResponseDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Alias { get; set; }
    }
}

