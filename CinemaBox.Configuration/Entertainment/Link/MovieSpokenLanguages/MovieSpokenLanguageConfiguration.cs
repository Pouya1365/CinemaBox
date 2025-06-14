using CinemaBox.Domain.Entertainment.Link.MovieSpokenLanguages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaBox.Configuration.Entertainment.Link.MovieSpokenLanguages;

public class MovieSpokenLanguageConfiguration : IEntityTypeConfiguration<MovieSpokenLanguage>
{
    public void Configure(EntityTypeBuilder<MovieSpokenLanguage> builder)
    {
        builder.ToTable<MovieSpokenLanguage>(name: "MovieSpokenLanguages", schema: "Entertainment");

        builder.HasKey(msl => new { msl.MovieId, msl.LanguageId });
        builder.Property(msl => msl.LanguageId).HasColumnName("LanguageId").HasComment(comment: "شناسه زبان");
        builder.Property(msl => msl.MovieId).HasMaxLength(20).IsRequired().HasColumnName("MovieId").HasComment(comment: "شناسه فیلم");
        builder.HasOne(msl => msl.Movie).WithMany(msl => msl.MovieSpokenLanguages).HasForeignKey(msl => msl.MovieId);
        builder.HasOne(msl => msl.Language).WithMany(msl => msl.MovieSpokenLanguages).HasForeignKey(msl => msl.LanguageId);
    }
}