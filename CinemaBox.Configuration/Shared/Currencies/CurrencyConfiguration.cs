using CinemaBox.Domain.Shared.Currencies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaBox.Configuration.Shared.Currencies;

public class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
{
    public void Configure(EntityTypeBuilder<Currency> builder)
    {
        builder.ToTable<Currency>(name: "Currencies", schema: "Shared");

        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).UseIdentityColumn().ValueGeneratedOnAdd().IsRequired().HasColumnName("CurrencyId").HasComment(comment: "شناسه واحد پولی");
        builder.Property(c => c.CurrencyName).HasMaxLength(50).IsRequired(true).HasComment(comment: "عنوان واحد پولی");
        builder.HasMany(c => c.Movies).WithOne(c => c.Currency).HasForeignKey(c => c.BudgetCurrencyId);
    }
}