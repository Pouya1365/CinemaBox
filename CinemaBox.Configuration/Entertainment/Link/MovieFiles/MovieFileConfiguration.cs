using CinemaBox.Domain.Entertainment.Link.MovieFiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaBox.Configuration.Entertainment.Link.MovieFiles;

public class MovieFileConfiguration : IEntityTypeConfiguration<MovieFile>
{
    public void Configure(EntityTypeBuilder<MovieFile> builder)
    {
        builder.ToTable<MovieFile>(name: "MovieFiles", schema: "Entertainment");
        builder.HasKey(mf => new { mf.MovieId, mf.FileId });

        builder.Property(mf => mf.MovieId).HasMaxLength(20).IsRequired().HasComment(comment: "شناسه فیلم");
        builder.Property(mf => mf.FileId).IsRequired(true).HasComment(comment: "شناسه فایل");
        builder.HasOne(mf => mf.File).WithMany(mf => mf.MovieFiles).HasForeignKey(mf => mf.FileId);
        builder.HasOne(mf => mf.Movie).WithMany(mf => mf.MovieFiles).HasForeignKey(mf => mf.MovieId);

    }
}