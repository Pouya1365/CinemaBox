using CinemaBox.Domain.Entertainment.Collections;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace CinemaBox.Configuration.Entertainment.Collections;
public class CollectionConfiguration : IEntityTypeConfiguration<Collection>
{
    public void Configure(EntityTypeBuilder<Collection> builder)
    {
        builder.ToTable<Collection>(name: "Collections", schema: "Entertainment");

        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).UseIdentityColumn().ValueGeneratedOnAdd().IsRequired().HasColumnName("CollectionId").HasComment(comment: "شناسه کالکشن");
        builder.Property(c => c.EnCollectionName).HasMaxLength(50).IsRequired(true).HasComment(comment: "نام کالکشن انگلیسی");
        builder.Property(c => c.FaCollectionName).HasMaxLength(50).IsRequired(true).HasComment(comment: "نام کالکشن فارسی");
        builder.HasMany(c => c.Movies).WithOne(c => c.Collection).HasForeignKey(c => c.CollectionId);
    }
}