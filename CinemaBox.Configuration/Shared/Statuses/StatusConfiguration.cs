using CinemaBox.Domain.Shared.Statuses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaBox.Configuration.Shared.Statuses;

public class StatusConfiguration : IEntityTypeConfiguration<Status>
{
    public void Configure(EntityTypeBuilder<Status> builder)
    {
        builder.ToTable<Status>(name: "Statuses", schema: "Shared");

        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id).UseIdentityColumn().ValueGeneratedOnAdd().IsRequired().HasColumnName("StatusId").HasComment(comment: "شناسه وضعیت");
        builder.Property(s => s.SatusName).HasMaxLength(50).IsRequired(true).HasComment(comment: "عنوان زبان انگلیسی");
        builder.HasData(
            new Status { SatusName = "درخواست", Id = 1 },
            new Status { SatusName = "آرشیو", Id = 2 }
            );
    }
}