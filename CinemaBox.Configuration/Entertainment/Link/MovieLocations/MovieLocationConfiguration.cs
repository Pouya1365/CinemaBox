using CinemaBox.Domain.Entertainment.Link.MovieLocations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaBox.Configuration.Entertainment.Link.MovieLocations;

public class MovieLocationConfiguration : IEntityTypeConfiguration<MovieLocation>
{
    public void Configure(EntityTypeBuilder<MovieLocation> builder)
    {
        builder.ToTable<MovieLocation>(name: "MovieLocations", schema: "Entertainment");

        builder.HasKey(ml => ml.Id);
        builder.Property(ml => ml.Id).UseIdentityColumn().ValueGeneratedOnAdd().IsRequired().HasComment(comment: "شناسه محل فیلم برداری");
        builder.Property(ml => ml.MovieId).HasMaxLength(20).IsRequired().HasColumnName("MovieId").HasComment(comment: "شناسه فیلم");
        builder.Property(ml => ml.LocationName).HasMaxLength(200).IsRequired().HasComment(comment: "محل فیلم برداری");
        builder.HasOne(ml => ml.Movie).WithMany(ml => ml.MovieLocations).HasForeignKey(ml => ml.MovieId);
    }
}