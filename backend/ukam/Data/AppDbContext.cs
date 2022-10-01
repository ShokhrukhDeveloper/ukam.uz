using Backend.Uckam.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ukam.Entities;

namespace Backend.Uckam.data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User>? Users { get; set; }
<<<<<<< HEAD
    public DbSet<Category> Categories { get; set; }
    // public override int SaveChanges()
    // {
    //     SetDates();
=======
    public override int SaveChanges()
    {
        SetDates();
>>>>>>> 8ba154b009a397289dd4d07b664bc6d2652bf337

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
}
