using CinemaBox.Domain.Person.PeopleFiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaBox.Configuration.Person.PeopleFiles;

public class PeopleFileConfiguration : IEntityTypeConfiguration<PeopleFile>
{
    public void Configure(EntityTypeBuilder<PeopleFile> builder)
    {
        builder.ToTable<PeopleFile>(name: "PeopleFiles", schema: "Person");

        builder.HasKey(pf => new { pf.PeopleId, pf.FileId });
        builder.Property(pf => pf.PeopleId).HasMaxLength(20).IsRequired().HasComment(comment: "شناسه بازیگر");
        builder.Property(pf => pf.FileId).IsRequired(true).HasComment(comment: "شناسه فایل");
        builder.HasOne(pf => pf.File).WithMany(pf => pf.PeopleFiles).HasForeignKey(pf => pf.FileId);
        builder.HasOne(pf => pf.People).WithMany(pf => pf.PeopleFiles).HasForeignKey(pf => pf.PeopleId);
    }
}