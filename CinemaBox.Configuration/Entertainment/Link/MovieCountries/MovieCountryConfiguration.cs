using CinemaBox.Domain.Entertainment.Link.MovieCountries;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaBox.Configuration.Entertainment.Link.MovieCountries;

public class MovieCountryConfiguration : IEntityTypeConfiguration<MovieCountry>
{
    public void Configure(EntityTypeBuilder<MovieCountry> builder)
    {
        builder.ToTable<MovieCountry>(name: "MovieCountries", schema: "Entertainment");

        builder.HasKey(mc => new { mc.MovieId, mc.CountryPartId });
        builder.Property(mc => mc.CountryPartId).HasMaxLength(20).IsRequired().HasColumnName("CountryPartId").HasComment(comment: "شناسه کشور");
        builder.Property(mc => mc.MovieId).HasMaxLength(20).IsRequired().HasColumnName("MovieId").HasComment(comment: "شناسه فیلم");
        builder.HasOne(mc => mc.Movie).WithMany(mc => mc.MovieCountries).HasForeignKey(mc => mc.MovieId);
        builder.HasOne(mc => mc.CountryPart).WithMany(mc => mc.MovieCountries).HasForeignKey(mc => mc.CountryPartId);
    }
}