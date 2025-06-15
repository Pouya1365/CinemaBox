using CinemaBox.Domain.Users.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaBox.Configuration.Users.Users;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable<User>(name: "Users", schema: "Usr");

        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).HasMaxLength(10).HasColumnName("UserId").HasComment(comment: "شناسه کاربر");
        builder.Property(c => c.Password).HasMaxLength(250).IsRequired(true).HasComment(comment: "رمز عبور");
    }
}