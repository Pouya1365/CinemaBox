using CinemaBox.Domain.Entertainment.Link.MovieCredits;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaBox.Configuration.Entertainment.Link.MovieCredits;

public class MovieCreditCounfiguration : IEntityTypeConfiguration<MovieCredit>
{
    public void Configure(EntityTypeBuilder<MovieCredit> builder)
    {
        builder.ToTable<MovieCredit>(name: "MovieCredits", schema: "Entertainment");

        builder.HasKey(mc => new { mc.PeopleId, mc.MovieId, mc.CreditTypeId });
        builder.Property(mc => mc.PeopleId).HasMaxLength(20).IsRequired().HasColumnName("PeopleId").HasComment(comment: "شناسه بازیگر");
        builder.Property(mc => mc.MovieId).HasMaxLength(20).IsRequired().HasColumnName("MovieId").HasComment(comment: "شناسه فیلم");
        builder.Property(mc => mc.CreditTypeId).IsRequired().HasComment(comment: "خلاصه نوع عامل");
        builder.Property(mc => mc.IsLead).IsRequired(false).HasComment(comment: "بازیگر اصلی");
        builder.Property(mc => mc.RoleName).HasMaxLength(150).IsRequired(false).HasComment(comment: "نام نقش");
        builder.HasOne(mc => mc.People).WithMany(mc => mc.MovieCredits).HasForeignKey(mc => mc.PeopleId);
        builder.HasOne(mc => mc.Movie).WithMany(mc => mc.MovieCredits).HasForeignKey(mc => mc.MovieId);
        builder.HasOne(mc => mc.CreditType).WithMany(mc => mc.MovieCredits).HasForeignKey(mc => mc.CreditTypeId);
    }
}