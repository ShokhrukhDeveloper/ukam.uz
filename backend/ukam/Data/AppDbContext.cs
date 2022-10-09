#pragma warning disable
using Backend.Uckam.Entities;
using Backend.Uckam.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;


namespace Backend.Uckam.data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CategoryType>()
            .HasOne<Category>(c => c.Category)
            .WithMany(g => g.CategoryTypes)
            .HasForeignKey(s => s.CategoryId);

        modelBuilder.Entity<CategoryType>()
            .HasOne<User>(c => c.User)
            .WithMany(g => g.CategoryTypes)
            .HasForeignKey(s => s.CreatorId);

        modelBuilder.Entity<Book>()
            .HasOne<User>(u => u.Users)
            .WithMany(b => b.Books)
            .HasForeignKey(u => u.UserId);

        modelBuilder.Entity<Book>()
            .HasOne<CategoryType>(c => c.Types)
            .WithMany(g => g.Books)
            .HasForeignKey(s => s.TypeId);

        modelBuilder.Entity<Category>()
            .HasMany<CategoryType>(g => g.CategoryTypes)
            .WithOne(s => s.Category)
            .HasForeignKey(s => s.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
    public DbSet<User>? Users { get; set; }
    public DbSet<Category>? Categories { get; set; }
    public DbSet<CategoryType>? CategoryTypes { get; set; }
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
