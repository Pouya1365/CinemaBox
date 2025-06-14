using CinemaBox.Domain.Division.CountryPartTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaBox.Configuration.Division.CountryPartTypes;

public class CountryPartTypeConfiguration : IEntityTypeConfiguration<CountryPartType>
{
    public void Configure(EntityTypeBuilder<CountryPartType> builder)
    {
        builder.ToTable(name: "CountryPartTypes", schema: "Division");

        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id).UseIdentityColumn().ValueGeneratedOnAdd().IsRequired(required: true).HasColumnName(name: "CountryPartTypeId").HasComment(comment: "شناسه نوع تقسیم بندی");
        builder.Property(m => m.CountryPartTypeName).HasMaxLength(50).IsRequired(true).HasComment(comment: "عنوان نوع تقسیم بندی");
        builder.HasData(new CountryPartType { CountryPartTypeName = "کشور", Id = 1 },
            new CountryPartType { CountryPartTypeName = "استان", Id = 2 },
            new CountryPartType { CountryPartTypeName = "شهرستان", Id = 3 }
            );
    }
}