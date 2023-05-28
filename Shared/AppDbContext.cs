using Microsoft.EntityFrameworkCore;

using feedApi.Roles;
using feedApi.Users;
using EntityFramework.Exceptions.PostgreSQL;

namespace feedApi.AppDbContextNS;

public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseExceptionProcessor();
    }
    public virtual DbSet<User> User { get; set; }
    public virtual DbSet<Role> Role { get; set; }

}