using CinemaBox.Domain.Entertainment.Link.MovieTaglines;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaBox.Configuration.Entertainment.Link.MovieTaglines;

public class MovieTaglineConfiguration : IEntityTypeConfiguration<MovieTagline>
{
    public void Configure(EntityTypeBuilder<MovieTagline> builder)
    {
        builder.ToTable<MovieTagline>(name: "MovieTaglines", schema: "Entertainment");

        builder.HasKey(mt => mt.Id);
        builder.Property(mt => mt.Id).UseIdentityColumn().ValueGeneratedOnAdd().IsRequired().HasComment(comment: "شناسه جمله نهایی");
        builder.Property(mt => mt.MovieId).HasMaxLength(20).IsRequired().HasColumnName("MovieId").HasComment(comment: "شناسه فیلم");
        builder.Property(mt => mt.EnTagline).HasMaxLength(500).IsRequired().HasComment(comment: "محل جمله نهایی انگلیسی");
        builder.Property(mt => mt.FaTagline).HasMaxLength(500).HasComment(comment: "محل جمله نهایی فارسی");
        builder.HasOne(mt => mt.Movie).WithMany(mt => mt.MovieTaglines).HasForeignKey(mt => mt.MovieId);
    }
}