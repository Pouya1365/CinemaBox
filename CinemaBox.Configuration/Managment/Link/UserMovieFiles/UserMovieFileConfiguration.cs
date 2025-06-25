
using CinemaBox.Domain.Managment.Link.UserMovieFiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaBox.Configuration.Managment.Link.UserMovieFiles;

public class UserMovieFileConfiguration : IEntityTypeConfiguration<UserMovieFile>
{
    public void Configure(EntityTypeBuilder<UserMovieFile> builder)
    {
        builder.ToTable<UserMovieFile>(name: "UserMovieFile", schema: "Managment");
        builder.HasKey(mf => new { mf.MovieId, mf.FileId });
        builder.Property(mf => mf.MovieId).HasMaxLength(20).IsRequired().HasComment(comment: "شناسه فیلم");
        builder.Property(mf => mf.FileId).IsRequired(true).HasComment(comment: "شناسه فایل");
        builder.HasOne(mf => mf.File).WithMany(mf => mf.UserMovieFile).HasForeignKey(mf => mf.FileId);
        builder.HasOne(mf => mf.Movie).WithMany(mf => mf.UserMovieFile).HasForeignKey(mf => mf.MovieId);
    }
}