using CinemaBox.Domain.Entertainment.Link.MovieKeywords;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaBox.Configuration.Entertainment.Link.MovieKeywords;

public class MovieKeywordConfiguration : IEntityTypeConfiguration<MovieKeyword>
{
    public void Configure(EntityTypeBuilder<MovieKeyword> builder)
    {
        builder.ToTable<MovieKeyword>(name: "MovieKeywords", schema: "Entertainment");
        builder.HasKey(mk => new { mk.MovieId, mk.KeywordId });

        builder.Property(mk => mk.MovieId).HasMaxLength(20).IsRequired().HasComment(comment: "شناسه فیلم");
        builder.Property(mk => mk.KeywordId).HasMaxLength(20).IsRequired(true).HasComment(comment: "شناسه کلمه کلیدی");
        builder.HasOne(mk => mk.Keyword).WithMany(mk => mk.MovieKeywords).HasForeignKey(mk => mk.KeywordId);
        builder.HasOne(mk => mk.Movie).WithMany(mk => mk.MovieKeywords).HasForeignKey(mk => mk.MovieId);

    }
}