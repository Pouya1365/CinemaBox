using CinemaBox.Domain.Entertainment.Link.MovieGenres;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaBox.Configuration.Entertainment.Link.MovieGenres;

public class MovieGenreConfiguration : IEntityTypeConfiguration<MovieGenre>
{
    public void Configure(EntityTypeBuilder<MovieGenre> builder)
    {
        builder.ToTable<MovieGenre>(name: "MovieGenres", schema: "Entertainment");

        builder.HasKey(mg => new { mg.MovieId, mg.GenreId });
        builder.Property(mg => mg.GenreId).IsRequired().HasComment(comment: "شناسه ژانر");
        builder.Property(mg => mg.MovieId).HasMaxLength(20).IsRequired().HasColumnName("MovieId").HasComment(comment: "شناسه فیلم");
        builder.HasOne(mg => mg.Movie).WithMany(mg => mg.MovieGenres).HasForeignKey(mg => mg.MovieId);
        builder.HasOne(mg => mg.Genre).WithMany(mg => mg.MovieGenres).HasForeignKey(mg => mg.GenreId);
    }
}