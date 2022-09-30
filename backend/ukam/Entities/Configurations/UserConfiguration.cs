using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Uckam.Entities.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public virtual void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(u => u.PasswordHash).HasMaxLength(64).IsRequired(true);
        builder.Property(u => u.UserImage).HasColumnType("nvarchar(50)");
        builder.Property(u => u.FirstName).HasColumnType("nvarchar(50)");
        builder.Property(u => u.UserName).HasColumnType("nvarchar(50)");
        builder.Property(u => u.LastName).HasColumnType("nvarchar(50)");
        builder.Property(u => u.Role).IsRequired();
        builder.Property(u => u.Language).IsRequired();
    }
}