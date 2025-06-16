using CinemaBox.Domain.Managment.Link.UserMovieAudios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaBox.Configuration.Managment.Link.UserMovieAudios;

public class UserMovieAudioConfiguration : IEntityTypeConfiguration<UserMovieAudio>
{
    public void Configure(EntityTypeBuilder<UserMovieAudio> builder)
    {
        builder.ToTable<UserMovieAudio>(name: "UserMovieAudios", schema: "Managment");

        builder.HasKey(ua => ua.Id);
        builder.Property(ua => ua.Id).ValueGeneratedOnAdd().UseIdentityColumn().HasColumnName("UserMovieAudioId").HasComment(comment: "شناسه فایل صوت");
        builder.Property(ua => ua.MovieId).IsRequired().HasMaxLength(20).HasComment(comment: "شناسه فیلم");
        builder.Property(ua => ua.UserId).IsRequired().HasMaxLength(10).HasComment(comment: "شناسه فرد");
        builder.Property(ua => ua.FormatId).HasComment(comment: "شناسه نوع فرمت");
        builder.Property(ua => ua.LanguageId).HasComment(comment: "شناسه زبان");
        builder.Property(ua => ua.Channels).HasComment(comment: "فریم در ثانیه");
        builder.HasOne(ua => ua.Format).WithMany(ua => ua.UserMovieAudios).HasForeignKey(ua => ua.FormatId);
        builder.HasOne(ua => ua.Language).WithMany(ua => ua.UserMovieAudios).HasForeignKey(ua => ua.LanguageId);
        builder.HasOne(ua => ua.Movie).WithMany(ua => ua.UserMovieAudios).HasForeignKey(ua => ua.MovieId);
        builder.HasOne(ua => ua.User).WithMany(ua => ua.UserMovieAudios).HasForeignKey(ua => ua.UserId);
    }
}