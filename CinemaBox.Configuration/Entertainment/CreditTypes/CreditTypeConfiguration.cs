using CinemaBox.Domain.Entertainment.CreditTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaBox.Configuration.Entertainment.CreditTypes;

public class CreditTypeConfiguration : IEntityTypeConfiguration<CreditType>
{
    public void Configure(EntityTypeBuilder<CreditType> builder)
    {
        builder.ToTable<CreditType>(name: "CreditTypes", schema: "Entertainment");

        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id).UseIdentityColumn().ValueGeneratedOnAdd().IsRequired(required: true).HasColumnName(name: "CreditTypeId").HasComment(comment: "شناسه نوع عوامل");
        builder.Property(m => m.EnCreditTypeName).IsRequired(true).HasMaxLength(50).HasComment(comment: "نوع عوامل انگلیسی");
        builder.Property(m => m.FaCreditTypeName).IsRequired(false).HasMaxLength(50).HasComment(comment: "نوع عوامل فارسی");
        builder.HasData(
            new CreditType { Id = 1, EnCreditTypeName = "Director", FaCreditTypeName = "کارگردان" },
            new CreditType { Id = 2, EnCreditTypeName = "Writers", FaCreditTypeName = "نویسنده" },
            new CreditType { Id = 3, EnCreditTypeName = "Cast", FaCreditTypeName = "بازیگران" },
            new CreditType { Id = 4, EnCreditTypeName = "Producers", FaCreditTypeName = "تهیه کنندکان" }
            );
    }
}