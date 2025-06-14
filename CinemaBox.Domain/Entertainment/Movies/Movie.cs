using CinemaBox.Domain.Entertainment.Certificates;
using CinemaBox.Domain.Entertainment.Collections;
using CinemaBox.Domain.Entertainment.Link.MovieCompanies;
using CinemaBox.Domain.Entertainment.Link.MovieCountries;
using CinemaBox.Domain.Entertainment.Link.MovieCredits;
using CinemaBox.Domain.Entertainment.Link.MovieFiles;
using CinemaBox.Domain.Persistent;
using CinemaBox.Domain.Shared.Currencies;

namespace CinemaBox.Domain.Entertainment.Movies;
public class Movie : PersistentObject<string>
{
    /// <summary>
    /// عنوان انگلیسی
    /// </summary>
    public string? EnTitle { get; set; }
    /// <summary>
    /// عنوان فارسی
    /// </summary>
    public string? FaTitle { get; set; }
    /// <summary>
    /// عنوان اصلی
    /// </summary>
    public string? OriginalTitle { get; set; }
    /// <summary>
    /// سال فیلم/تاریخ شروع سریال
    /// </summary>
    public long? StartYear { get; set; }
    /// <summary>
    /// تاریخ پایان سریال
    /// </summary>
    public long? EndYear { get; set; }
    /// <summary>
    /// شناسه درجه سنی
    /// </summary>
    public byte? CertificateId { get; set; }
    /// <summary>
    /// مدت زمان فیلم دقیقه
    /// </summary>
    public long? RunTimeMinutes { get; set; }
    /// <summary>
    /// سال انتشار
    /// </summary>
    public long? ReleaseYear { get; set; }
    /// <summary>
    /// ماه انتشار
    /// </summary>
    public long? ReleaseMonth { get; set; }
    /// <summary>
    /// روز انتشار
    /// </summary>
    public long? ReleaseDay { get; set; }
    /// <summary>
    /// رتبه بندی کل
    /// </summary>
    public decimal? AggregateRating { get; set; }
    /// <summary>
    /// تعداد رای دهندگان
    /// </summary>
    public long? VoteCount { get; set; }
    /// <summary>
    /// تعداد جوایز
    /// </summary>
    public long? Winner { get; set; }
    /// <summary>
    /// نامزد شدن
    /// </summary>
    public long? Nomination { get; set; }
    /// <summary>
    /// خلاصه داستان انگلیسی
    /// </summary>
    public string? EnPlot { get; set; }
    /// <summary>
    ///  داستان انگلیسی
    /// </summary>
    public string? EnStoryline { get; set; }
    /// <summary>
    /// بودجه
    /// </summary>
    public double? Budget { get; set; }
    /// <summary>
    ///  داستان فارسی
    /// </summary>
    public string? FaStoryline { get; set; }
    /// <summary>
    /// برترین فیلم
    /// </summary>
    public byte? TopRank { get; set; }
    /// <summary>
    /// تعداد برنده اسکار
    /// </summary>
    public byte? OscarWins { get; set; }
    /// <summary>
    /// تعداد نامزد اسکار
    /// </summary>
    public byte? OscarNominations { get; set; }
    /// <summary>
    /// شناسه واحد پول
    /// </summary>
    public byte? BudgetCurrencyId { get; set; }
    public bool? IsTvShow { get; set; }
    public int? CollectionId { get; set; }
    public Certificate? Certificate { get; set; }
    public Currency? Currency { get; set; }
    public Collection? Collection { get; set; }
    public ICollection<MovieCompany> MovieCompanies { get; set; } = [];
    public ICollection<MovieCountry> MovieCountries { get; set; } = [];
    public ICollection<MovieCredit> MovieCredits { get; set; } = [];
    public ICollection<MovieFile> MovieFiles { get; set; } = [];
    //

    //public ICollection<MovieGenre> MovieGenres { get; set; } = [];
    //public ICollection<MovieLocation> MovieLocations { get; set; } = [];
    //public ICollection<MovieSpokenLanguage> MovieSpokenLanguages { get; set; } = [];
    //public ICollection<MovieTagline> MovieTaglines { get; set; } = [];
    //public ICollection<MovieKeyword> MovieKeywords { get; set; } = [];
    //public ICollection<UserMovieVideo> UserMovieVideos { get; set; } = [];
    //public ICollection<UserMovieDisk> UserMovieDisks { get; set; } = [];
    //
}