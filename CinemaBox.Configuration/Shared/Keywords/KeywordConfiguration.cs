using CinemaBox.Domain.Shared.Keywords;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaBox.Configuration.Shared.Keywords;


public class KeywordConfiguration : IEntityTypeConfiguration<Keyword>
{
    public void Configure(EntityTypeBuilder<Keyword> builder)
    {
        builder.ToTable<Keyword>(name: "Keywords", schema: "Shared");

        builder.HasKey(k => k.Id);
        builder.Property(k => k.Id).HasMaxLength(20).IsRequired(required: true).HasColumnName(name: "KeywordId").HasComment(comment: "شناسه کلمه کلیدی");
        builder.Property(k => k.EnKeyowrdName).IsRequired(true).HasMaxLength(150).HasComment(comment: "کلمه کلیدی انگلیسی");
        builder.Property(k => k.FaKeyowrdName).IsRequired(false).HasMaxLength(50).HasComment(comment: "کلمه کلیدی فارسی");
    }
}