using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace feedApi.Users;

[Index(nameof(Email), IsUnique = true)]
public class User
{
    [Key]
    public int id { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.Now.ToUniversalTime();

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }
}

