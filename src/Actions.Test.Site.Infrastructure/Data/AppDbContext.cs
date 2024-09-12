
using Actions.Test.Site.Domain.Entities;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<UserEntity> Users { get; set; }
    public DbSet<RoleEntity> Roles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<UserEntity>()
           .HasOne(u => u.Role)
        .WithMany(r => r.Users)
        .HasForeignKey(u => u.RoleId)
        .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<RoleEntity>()
          .Property(r => r.Id);

        base.OnModelCreating(modelBuilder);
    }
}
