using CinemaBox.Domain.Managment.Link.UserMovieDisks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaBox.Configuration.Managment.Link.UserMovieDisks;

public class UserMovieDiskConfiguration : IEntityTypeConfiguration<UserMovieDisk>
{
    public void Configure(EntityTypeBuilder<UserMovieDisk> builder)
    {
        builder.ToTable(name: "UserMovieDisks", schema: "Managment");

        builder.HasKey(umd => umd.Id);
        builder.Property(umd => umd.Id).HasMaxLength(20).HasColumnName("MovieId").HasComment(comment: "شناسه فیلم");
        builder.Property(umd => umd.PositionMovie).HasMaxLength(50).HasComment(comment: "محل قرارگیری فیلم");
        builder.Property(umd => umd.IsSubtitle).HasComment(comment: "زیرنویس فارسی");
        builder.Property(umd => umd.MyTime).HasComment(comment: "زمان فیلم من");
        builder.Property(umd => umd.MovieNumber).HasComment(comment: "شماره فیلم");
        builder.Property(umd => umd.FileName).HasComment(comment: "نام فایل");
        builder.Property(umd => umd.FileSize).HasComment(comment: "اندازه فایل");
        builder.Property(umd => umd.IsDubbed).HasComment(comment: "دوبله");
        builder.Property(umd => umd.IsSubtitle).HasComment(comment: "زیرنویس");
        builder.Property(umd => umd.StatusId).HasComment(comment: "شناسه وضعیت");
        builder.Property(umd => umd.Description).HasMaxLength(250).HasComment(comment: "توضیحات");
        builder.HasOne(umd => umd.Movie).WithMany(umd => umd.UserMovieDisks).HasForeignKey(umd => umd.Id);
        builder.HasOne(umd => umd.Status).WithMany(umd => umd.UserMovieDisks).HasForeignKey(umd => umd.StatusId);
    }
}
