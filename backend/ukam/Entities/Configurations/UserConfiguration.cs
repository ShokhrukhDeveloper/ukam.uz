using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Uckam.Entities.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public virtual void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(u => u.PhoneNumber).HasColumnType("nvarchar(15)").IsRequired(true);
        builder.Property(u => u.PasswordHash).HasMaxLength(64).IsRequired(true);
        builder.Property(u => u.UserImage).HasColumnType("nvarchar(50)").IsRequired(true);
        builder.Property(u => u.Role).IsRequired(true);
        builder.Property(u => u.Language).IsRequired(true);
    }
}