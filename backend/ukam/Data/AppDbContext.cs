#pragma warning disable
using Backend.Uckam.Entities;
using Backend.Uckam.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;


namespace Backend.Uckam.data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User>? Users { get; set; }
    public DbSet<Category>? Categories { get; set; }
    public DbSet<Book>? Books { get; set; }
    public override int SaveChanges()
    {
        AddNameHash();
        SetDates();

        return base.SaveChanges();
    }
    private void SetDates()
    {
        foreach (var entry in ChangeTracker.Entries<EntityBase>())
        {
            if (entry.State == EntityState.Added)
                entry.Entity.CreatedAt = DateTime.Now;
            entry.Entity.UpdatedAt = DateTime.Now;

            if (entry.State == EntityState.Modified)
                entry.Entity.UpdatedAt = DateTime.Now;
        }
    }

    private void AddNameHash()
    {
        foreach (var entry in ChangeTracker.Entries<User>())
        {
            if (entry.Entity is User user)
                user.PasswordHash = user?.PasswordHash?.ToLower().Sha256();
        }
    }
}
