using CinemaBox.Domain.Entertainment.Certificates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaBox.Configuration.Entertainment.Certificates;

public class CertificateConfiguration : IEntityTypeConfiguration<Certificate>
{
    public void Configure(EntityTypeBuilder<Certificate> builder)
    {
        builder.ToTable<Certificate>(name: "Certificates", schema: "Entertainment");

        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id)
               .UseIdentityColumn()
               .ValueGeneratedOnAdd()
               .IsRequired()
               .HasColumnName("CertificateId").HasComment(comment: "شناسه زده بندی سنی");
        builder.Property(c => c.CertificateName).HasMaxLength(20).IsRequired(true).HasComment(comment: "نام درجه بندی");

    }
}