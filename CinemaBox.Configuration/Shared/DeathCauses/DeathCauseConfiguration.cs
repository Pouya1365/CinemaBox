using CinemaBox.Domain.Shared.DeathCauses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaBox.Configuration.Shared.DeathCauses;

public class DeathCauseConfiguration : IEntityTypeConfiguration<DeathCause>
{
    public void Configure(EntityTypeBuilder<DeathCause> builder)
    {
        builder.ToTable<DeathCause>(name: "DeathCauses", schema: "Shared");

        builder.HasKey(dc => dc.Id);
        builder.Property(dc => dc.Id).UseIdentityColumn().ValueGeneratedOnAdd().IsRequired().HasColumnName("DeathCauseId").HasComment(comment: "شناسه نوع فوت");
        builder.Property(dc => dc.EnDeathCauseName).HasMaxLength(100).IsRequired(true).HasComment(comment: "عنوان فوت انگلیسی");
        builder.Property(dc => dc.FaDeathCauseName).HasMaxLength(100).IsRequired(false).HasComment(comment: "عنوان فوت فارسی");
        builder.HasMany(dc => dc.People).WithOne(dc => dc.DeathCause).HasForeignKey(dc => dc.DeathCauseId);
    }
}