using CinemaBox.Domain.Shared.Qualities.QualityTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaBox.Configuration.Shared.Qualities.QualityTypes;

public class QualityTypeConfiguration : IEntityTypeConfiguration<QualityType>
{
    public void Configure(EntityTypeBuilder<QualityType> builder)
    {
        builder.ToTable(name: "QualityTypes", schema: "Shared");

        builder.HasKey(qt => qt.Id);
        builder.Property(qt => qt.Id).ValueGeneratedOnAdd().UseIdentityColumn().HasColumnName(name: "QualityTypeId").HasComment(comment: "شناسه نوع کیفیت کلیدی");
        builder.Property(qt => qt.QualityTypeName).IsRequired(true).HasMaxLength(50).HasComment(comment: "عنوان نوع کیفیت");
        builder.HasData(new QualityType { Id = 1, QualityTypeName = "BluRay" }, new QualityType { Id = 2, QualityTypeName = "WebDl" });
    }
}