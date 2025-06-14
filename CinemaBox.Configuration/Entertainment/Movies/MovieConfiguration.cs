

using CinemaBox.Domain.Entertainment.Movies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaBox.Configuration.Entertainment.Movies;

public class MovieConfiguration : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.ToTable<Movie>(name: "Movies", schema: "Entertainment");

        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id).HasMaxLength(20).IsRequired(required: true).HasColumnName(name: "MovieId").HasComment(comment: "شناسه فیلم یا سریال");
        builder.Property(m => m.VoteCount).HasComment(comment: "تعداد رای دهندگان");
        builder.Property(m => m.RunTimeMinutes).HasComment(comment: "مدت زمان فیلم یا سریال");
        builder.Property(m => m.StartYear).HasComment(comment: "سال فیلم یا سال شروع سریال");
        builder.Property(m => m.EnTitle).HasMaxLength(150).HasComment(comment: "عنوان انگلیسی");
        builder.Property(m => m.FaTitle).HasMaxLength(150).HasComment(comment: "عنوان فارسی");
        builder.Property(m => m.OriginalTitle).HasMaxLength(150).HasComment(comment: "عنوان اصلی");
        builder.Property(m => m.OriginalTitle).HasMaxLength(150).HasComment(comment: "عنوان اصلی");
        builder.Property(m => m.EndYear).HasComment(comment: "تاریخ پایان سریال");
        builder.Property(m => m.ReleaseYear).HasComment(comment: "سال انتشار");
        builder.Property(m => m.ReleaseMonth).HasComment(comment: "ماه انتشار");
        builder.Property(m => m.ReleaseDay).HasComment(comment: "روز انتشار");
        builder.Property(m => m.AggregateRating).HasComment(comment: "رتبه بندی کل");
        builder.Property(m => m.VoteCount).HasComment(comment: "تعداد رای دهندگان");
        builder.Property(m => m.Winner).HasComment(comment: "تعداد جوایز");
        builder.Property(m => m.Nomination).HasComment(comment: "نامزد شدن");
        builder.Property(m => m.CertificateId).HasComment(comment: "شناسه درجه بندی سنی");
        builder.Property(m => m.EnPlot).HasMaxLength(4000).HasComment(comment: "خلاصه داستان انگلیسی");
        builder.Property(m => m.EnStoryline).HasMaxLength(4000).HasComment(comment: "داستان انگلیسی");
        builder.Property(m => m.FaStoryline).HasMaxLength(4000).HasComment(comment: "داستان فارسی");
        builder.Property(m => m.Budget).HasComment(comment: "بودجه");
        builder.Property(m => m.TopRank).HasComment(comment: "برترین فیلم");
        builder.Property(m => m.OscarWins).HasComment(comment: "تعداد برنده اسکار");
        builder.Property(m => m.OscarNominations).HasComment(comment: "تعداد نامزد اسکار");
        builder.Property(m => m.BudgetCurrencyId).HasComment(comment: "شناسه واحد پول بودجه");
        builder.Property(m => m.CollectionId).HasComment(comment: "شناسه کالکشن");
        builder.Property(m => m.IsTvShow).HasComment(comment: "سریال");
       // builder.HasOne(m => m.Certificate).WithMany(m => m.Movies).HasForeignKey(x => x.CertificateId);
    }
}