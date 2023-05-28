using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace feedApi.Roles
{
    [Index(nameof(Name), IsUnique = true)]
    [Index(nameof(Alias), IsUnique = true)]
    public class Role
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Alias { get; set; }
    }
}

