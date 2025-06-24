using CinemaBox.Domain.Managment.Link.UserMovieAudios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaBox.Configuration.Managment.Link.UserMovieAudios;

public class UserMovieAudioConfiguration : IEntityTypeConfiguration<UserMovieAudio>
{
    public void Configure(EntityTypeBuilder<UserMovieAudio> builder)
    {
        builder.ToTable<UserMovieAudio>(name: "UserMovieAudios", schema: "Managment");

        builder.HasKey(ua => new { ua.MovieId,ua.LanguageId});
        builder.Property(ua => ua.MovieId).HasMaxLength(20).HasColumnName("MovieId").HasComment(comment: "شناسه فایل صوت");
        builder.Property(ua => ua.FormatId).HasComment(comment: "شناسه نوع فرمت");
        builder.Property(ua => ua.LanguageId).HasComment(comment: "شناسه زبان");
        builder.Property(ua => ua.Channels).HasComment(comment: "فریم در ثانیه");
        builder.HasOne(ua => ua.Format).WithMany(ua => ua.UserMovieAudios).HasForeignKey(ua => ua.FormatId);
        builder.HasOne(ua => ua.Language).WithMany(ua => ua.UserMovieAudios).HasForeignKey(ua => ua.LanguageId);
        builder.HasOne(ua => ua.Movie).WithMany(ua => ua.UserMovieAudios).HasForeignKey(ua => ua.MovieId);
    }
}