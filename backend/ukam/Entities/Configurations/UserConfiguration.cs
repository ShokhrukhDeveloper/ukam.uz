using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Uckam.Entities.Configurations;

public class UserConfiguration : EntityBaseConfiguration<User>
{
<<<<<<< HEAD


    public virtual void Configure(EntityTypeBuilder<User> builder)


=======
    public override void Configure(EntityTypeBuilder<User> builder)
>>>>>>> 96d028cf4aef39f4589e4a397099a6066787cb55
    {
        base.Configure(builder);
        builder.Property(u => u.PasswordHash).HasMaxLength(64).IsRequired(true);
        builder.Property(u => u.UserPath).HasColumnType("nvarchar(50)");
        builder.Property(u => u.FirstName).HasColumnType("nvarchar(50)");
        builder.Property(u => u.UserName).HasColumnType("nvarchar(50)");
        builder.Property(u => u.LastName).HasColumnType("nvarchar(50)");
        builder.Property(u => u.Role).IsRequired();
        builder.Property(u => u.Language).IsRequired();
    }

}