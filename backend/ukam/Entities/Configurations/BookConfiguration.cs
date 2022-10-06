using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Uckam.Entities.Configurations;

public class BookConfiguration : EntityBaseConfiguration<Book>
{
    public override void Configure(EntityTypeBuilder<Book> builder)
    {
        base.Configure(builder);
        builder.Property(b =>b.BookName).HasColumnType("varchar(100)").IsRequired(true);
        builder.Property(b =>b.Author).HasColumnType("varchar(50)").IsRequired(true);
        builder.Property(b =>b.Establish).HasColumnType("varchar(50)");
        builder.Property(b =>b.ConverImage).HasColumnType("varchar(50)");
        builder.Property(b =>b.BookPath).HasColumnType("varchar(50)");
    }
}