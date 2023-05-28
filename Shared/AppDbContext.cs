using Microsoft.EntityFrameworkCore;

using feedApi.Roles;
using feedApi.Users;

namespace feedApi.AppDbContextNS;

public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> User { get; set; }
    public virtual DbSet<Role> Role { get; set; }

}