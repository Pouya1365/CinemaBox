using CinemaBox.Domain.Entertainment.Coropration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaBox.Configuration.Entertainment.Coroprations;

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.ToTable<Company>(name: "Companies", schema: "Entertainment");

        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id).HasMaxLength(20).IsRequired(required: true).HasColumnName(name: "CompanyId").HasComment(comment: "شناسه شزکت");
        builder.Property(m => m.EnCompanyName).HasMaxLength(150).IsRequired(true).HasComment(comment: "عنوان شرکت انگلیسی");
        builder.Property(m => m.FaCompanyName).HasMaxLength(150).IsRequired(false).HasComment(comment: "عنوان شرکت فارسی");
    }
}