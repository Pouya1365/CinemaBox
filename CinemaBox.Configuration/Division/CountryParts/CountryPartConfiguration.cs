
using CinemaBox.Domain.Division.CountryParts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaBox.Configuration.Division.CountryParts;

public class CountryPartConfiguration : IEntityTypeConfiguration<CountryPart>
{
    public void Configure(EntityTypeBuilder<CountryPart> builder)
    {
        builder.ToTable<CountryPart>(name: "CountryParts", schema: "Division");

        builder.HasKey(cp => cp.Id);
        builder.Property(cp => cp.Id).UseIdentityColumn().ValueGeneratedOnAdd().IsRequired(required: true).HasColumnName(name: "CountryPartId").HasComment(comment: "شناسه کشور");
        builder.Property(cp => cp.IsoCode).HasMaxLength(10).IsRequired(false).HasComment(comment: "عنوان نوع تقسیم بندی");
        builder.Property(cp => cp.CountryPartTypeId).IsRequired(false).HasComment(comment: "شناسه نوع کشور");
        builder.Property(cp => cp.ParentId).IsRequired(false).HasComment(comment: "شناسه پدر");
        builder.Property(cp => cp.EnCountryPartName).HasMaxLength(150).IsRequired(true).HasComment(comment: "عنوان انگلیسی");
        builder.Property(cp => cp.FaCountryPartName).HasMaxLength(150).IsRequired(false).HasComment(comment: "عنوان فارسی");
        builder.HasOne(cp => cp.CountryPartType).WithMany(cp => cp.CountryParts).HasForeignKey(cp => cp.CountryPartTypeId);

    }
}