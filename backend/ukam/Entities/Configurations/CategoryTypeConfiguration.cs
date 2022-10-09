using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Uckam.Entities.Configurations;

public class CategoryTypeConfiguration : EntityBaseConfiguration<CategoryType>
{
    public override void Configure(EntityTypeBuilder<CategoryType> builder)
    {
        base.Configure(builder);
        builder.Property(t => t.Name).HasColumnType("nvarchar(50)").IsRequired();
    }
}