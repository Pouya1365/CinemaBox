using CinemaBox.Domain.Person.Peoples;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaBox.Configuration.Person.Peoples;

public class PeopleConfiguration : IEntityTypeConfiguration<People>
{
    public void Configure(EntityTypeBuilder<People> builder)
    {
        builder.ToTable<People>(name: "Peoples", schema: "Person");

        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).HasMaxLength(20).IsRequired().HasColumnName("PeopleId").HasComment(comment: "شناسه زده بندی سنی");
        builder.Property(c => c.EnMiniBiography).IsRequired(false).HasComment(comment: "خلاصه زندگینامه انگلیسی");
        builder.Property(c => c.FaMiniBiography).IsRequired(false).HasComment(comment: "خلاصه زندگینامه فارسی");
        builder.Property(c => c.BirthName).HasMaxLength(150).IsRequired(false).HasComment(comment: "نام تولد");
        builder.Property(c => c.BornDate).IsRequired(false).HasComment(comment: "تاریخ تولد");
        builder.Property(c => c.BornPlace).HasMaxLength(200).IsRequired(false).HasComment(comment: "محل تولد");
        builder.Property(c => c.DeathDate).IsRequired(false).HasComment(comment: "تاریخ فوت");
        builder.Property(c => c.DeathPlace).HasMaxLength(200).IsRequired(false).HasComment(comment: "محل فوت");
        builder.Property(c => c.EnFullName).HasMaxLength(200).IsRequired(true).HasComment(comment: "نام انگلیسی");
        builder.Property(c => c.FaFullName).HasMaxLength(200).IsRequired(false).HasComment(comment: "نام فارسی");
        builder.Property(c => c.Height).HasMaxLength(50).IsRequired(false).HasComment(comment: "قد");
        builder.Property(c => c.NickName).HasMaxLength(50).IsRequired(false).HasComment(comment: "معروف");
        builder.Property(c => c.AddedDate).IsRequired(true).HasComment(comment: "تاریخ اضافه شدن");
        builder.Property(c => c.UpdatedDate).IsRequired(true).HasComment(comment: "تاریخ بروز شدن");
        builder.Property(c => c.DeathCauseId).IsRequired(false).HasComment(comment: "شناسه دلیل فوت");
    }
}