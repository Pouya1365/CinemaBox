using CinemaBox.Domain.Entertainment.Genres;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaBox.Configuration.Entertainment.Genres;

public class GenreConfiguration : IEntityTypeConfiguration<Genre>
{
    public void Configure(EntityTypeBuilder<Genre> builder)
    {
        builder.ToTable<Genre>(name: "Genres", schema: "Entertainment");

        builder.HasKey(g => g.Id);
        builder.Property(g => g.Id).UseIdentityColumn().ValueGeneratedOnAdd().IsRequired(required: true).HasColumnName(name: "GenreId").HasComment(comment: "شناسه ژانر");
        builder.Property(g => g.EnGenreName).IsRequired(true).HasMaxLength(50).HasComment(comment: "ژانر انگلیسی");
        builder.Property(g => g.FaGenreName).IsRequired(false).HasMaxLength(50).HasComment(comment: "نوع ژانر فارسی");
        builder.Property(g => g.FileId).IsRequired(false).HasComment(comment: "شناسه فایل");
        builder.HasOne(g => g.File).WithMany(g => g.Genres).HasForeignKey(g => g.FileId);
    }
}