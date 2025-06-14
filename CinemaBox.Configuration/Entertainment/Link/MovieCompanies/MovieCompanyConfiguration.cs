using CinemaBox.Domain.Entertainment.Link.MovieCompanies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaBox.Configuration.Entertainment.Link.MovieCompanies;

public class MovieCompanyConfiguration : IEntityTypeConfiguration<MovieCompany>
{
    public void Configure(EntityTypeBuilder<MovieCompany> builder)
    {
        builder.ToTable<MovieCompany>(name: "MovieCompanies", schema: "Entertainment");

        builder.HasKey(mc => new { mc.MovieId, mc.CompanyId });
        builder.Property(mc => mc.CompanyId).HasMaxLength(20).IsRequired().HasColumnName("CompanyId").HasComment(comment: "شناسه شرکت");
        builder.Property(mc => mc.MovieId).HasMaxLength(20).IsRequired().HasColumnName("MovieId").HasComment(comment: "شناسه فیلم");
        builder.HasOne(mc => mc.Movie).WithMany(mc => mc.MovieCompanies).HasForeignKey(mc => mc.MovieId);
        builder.HasOne(mc => mc.Company).WithMany(mc => mc.MovieCompanies).HasForeignKey(mc => mc.CompanyId);
    }

}