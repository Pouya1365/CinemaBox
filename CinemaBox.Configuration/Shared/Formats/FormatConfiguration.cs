using CinemaBox.Domain.Shared.Formats;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaBox.Configuration.Shared.Formats;

public class FormatConfiguration : IEntityTypeConfiguration<Format>
{
    public void Configure(EntityTypeBuilder<Format> builder)
    {
        builder.ToTable<Format>(name: "Formats", schema: "Shared");

        builder.HasKey(f => f.Id);
        builder.Property(f => f.Id).UseIdentityColumn().ValueGeneratedOnAdd().IsRequired().HasColumnName("FormatId").HasComment(comment: "شناسه فرمت");
        builder.Property(f => f.FormatName).HasMaxLength(50).IsRequired(true).HasComment(comment: "عنوان فرمت");
    }
}
