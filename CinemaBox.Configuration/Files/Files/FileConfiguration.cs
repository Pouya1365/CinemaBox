using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaBox.Configuration.Files.Files;

public class FileConfiguration : IEntityTypeConfiguration<Domain.Files.Files.File>
{
    public void Configure(EntityTypeBuilder<Domain.Files.Files.File> builder)
    {
        builder.ToTable(name: "Files", schema: "Files");

        builder.HasKey(f => f.Id);
        builder.Property(f => f.Id).UseIdentityColumn().ValueGeneratedOnAdd().IsRequired().HasColumnName("FileId").HasComment(comment: "شناسه فایل");
        builder.Property(f => f.ServerId).HasComment(comment: "شناسه  سرور");
        builder.Property(f => f.FileName).HasMaxLength(150).HasComment(comment: "عنوان فایل");
        builder.HasOne(f => f.Server).WithMany(f => f.Files).HasForeignKey(f => f.ServerId);
    }
}