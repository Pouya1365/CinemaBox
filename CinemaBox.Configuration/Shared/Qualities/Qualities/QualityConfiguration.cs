using CinemaBox.Domain.Shared.Qualities.Qualities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaBox.Configuration.Shared.Qualities.Qualities;

public class QualityConfiguration : IEntityTypeConfiguration<Quality>
{
    public void Configure(EntityTypeBuilder<Quality> builder)
    {
        builder.ToTable(name: "Qualities", schema: "Shared");

        builder.HasKey(q => q.Id);
        builder.Property(q => q.Id).ValueGeneratedOnAdd().UseIdentityColumn().IsRequired(required: true).HasColumnName(name: "QualityId").HasComment(comment: "شناسه کیفیت کلیدی");
        builder.Property(q => q.QualityName).IsRequired(true).HasMaxLength(50).HasComment(comment: "عنوان کیفیت");
        builder.HasData(new Quality { Id=1, QualityName = "2160" }, new Quality {Id=2, QualityName = "1080" }, new Quality {Id=3, QualityName = "720" }, new Quality {Id=4,  QualityName = "480" });
    }
}