using Microsoft.EntityFrameworkCore;

namespace feedApi.Users;

public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> User { get; set; }

}