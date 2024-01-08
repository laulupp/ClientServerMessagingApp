using AuthService.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Persistence.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().ToTable("users", "auth_schema");
    }

    public DbSet<User> Users { get; set; }
}
