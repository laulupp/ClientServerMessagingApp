using Microsoft.EntityFrameworkCore;
using ServerApp.Models;

namespace ServerApp.Context;

class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Room>().ToTable("rooms", "server_schema");
        modelBuilder.Entity<Room>().HasIndex(p => p.Code).IsUnique();

        modelBuilder.Entity<UserRoomLink>().ToTable("user_room_links", "server_schema");
        modelBuilder.Entity<UserRoomLink>().HasIndex(p => new { p.Username, p.RoomId }).IsUnique();

        modelBuilder.Entity<ChatMessage>().ToTable("messages", "server_schema");
    }

    public DbSet<Room> Rooms { get; set; }
    public DbSet<UserRoomLink> UserRoomLinks { get; set; }
    public DbSet<ChatMessage> Messages { get; set; }
}
