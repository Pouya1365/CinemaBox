using CinemaBox.Domain.Shared.Languages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaBox.Configuration.Shared.Languages;

public class LanguageConfiguration : IEntityTypeConfiguration<Language>
{
    public void Configure(EntityTypeBuilder<Language> builder)
    {
        builder.ToTable<Language>(name: "Languages", schema: "Shared");

        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).UseIdentityColumn().ValueGeneratedOnAdd().IsRequired().HasColumnName("LanguageId").HasComment(comment: "شناسه زبان");
        builder.Property(c => c.EnLanguageName).HasMaxLength(50).IsRequired(true).HasComment(comment: "عنوان زبان انگلیسی");
        builder.Property(c => c.FaLanguageName).HasMaxLength(50).IsRequired(false).HasComment(comment: "عنوان زبان فارسی");
        builder.Property(c => c.IsoCode).HasMaxLength(10).IsRequired(false).HasComment(comment: "کد زبان");
    }
}