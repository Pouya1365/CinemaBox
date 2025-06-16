using CinemaBox.Domain.Managment.Link.UserMovieVideos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaBox.Configuration.Managment.Link.UserMovieVideos;

public class UserMovieVideoConfiguration : IEntityTypeConfiguration<UserMovieVideo>
{
    public void Configure(EntityTypeBuilder<UserMovieVideo> builder)
    {
        builder.ToTable<UserMovieVideo>(name: "UserMovieVideos", schema: "Managment");
        builder.HasKey(umv => new { umv.UserId,umv.MovieId});
        builder.Property(umv => umv.MovieId).HasMaxLength(20).HasComment(comment: "شناسه فیلم");
        builder.Property(umv => umv.UserId).HasMaxLength(10).HasComment(comment: "شناسه فرد");
        builder.Property(umv => umv.FormatId).HasComment(comment: "شناسه نوع فرمت");
        builder.Property(umv => umv.BitRate).HasMaxLength(50).HasComment(comment: "بیت ریت");
        builder.Property(umv => umv.FPS).HasMaxLength(50).HasComment(comment: "فریم در ثانیه");
        builder.Property(umv => umv.AspectRatio).HasMaxLength(50).HasComment(comment: "نسبت ابعاد");
        builder.Property(umv => umv.Resolution).HasMaxLength(50).HasComment(comment: "وضوح تصویر");
        builder.HasOne(umv => umv.Format).WithMany(umv => umv.UserMovieVideos).HasForeignKey(umv => umv.FormatId);
        builder.HasOne(umv => umv.Movie).WithMany(umv => umv.UserMovieVideos).HasForeignKey(umv => umv.MovieId);
        builder.HasOne(umv => umv.User).WithMany(umv => umv.UserMovieVideos).HasForeignKey(umv => umv.UserId);
    }
}