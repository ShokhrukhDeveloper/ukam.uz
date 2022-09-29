using Backend.Uckam.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Backend.Uckam.data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User>? Users { get; set; }
    // public override int SaveChanges()
    // {
    //     SetDates();

    //     return base.SaveChanges();
    // }
    // private void SetDates()
    // {
    //     foreach (var entry in ChangeTracker.Entries<EntityBase>())
    //     {
    //         if (entry.State == EntityState.Added)
    //             entry.Entity.CreatedAt = DateTime.UtcNow;
    //         entry.Entity.UpdatedAt = DateTime.UtcNow;

    //         if (entry.State == EntityState.Modified)
    //             entry.Entity.UpdatedAt = DateTime.UtcNow;
    //     }
    // }
}
