using CinemaBox.Domain.Entertainment.Certificates;
using CinemaBox.Domain.Entertainment.Collections;
using CinemaBox.Domain.Entertainment.Link.MovieCompanies;
using CinemaBox.Domain.Entertainment.Link.MovieCountries;
using CinemaBox.Domain.Entertainment.Link.MovieCredits;
using CinemaBox.Domain.Entertainment.Link.MovieGenres;
using CinemaBox.Domain.Entertainment.Link.MovieKeywords;
using CinemaBox.Domain.Entertainment.Link.MovieLocations;
using CinemaBox.Domain.Entertainment.Link.MovieTaglines;
using CinemaBox.Domain.Persistent;
using CinemaBox.Domain.Shared.Currencies;
namespace CinemaBox.Domain.Entertainment.Movies;
public class Movie : PersistentObject<int>
{
    public string? ImdbId { get; set; }
    public string? TmdbId { get; set; }
    public string? Title { get; set; }
    public string? PersianTitle { get; set; }
    public string? OriginalTitle { get; set; }
    public int? StartYear { get; set; }
    public int? EndYear { get; set; }
    public int? ReleaseYear { get; set; }
    public byte? ReleaseMonth { get; set; }
    public byte? ReleaseDay { get; set; }
    public int? RunTimeMinutes { get; set; }
    public byte? CertificateId { get; set; }
    public int? TotalSeasons { get; set; }
    public int? TotalEpisodes { get; set; }
    public decimal? AggregateRating { get; set; }
    public long? VoteCount { get; set; }
    public int? Winner { get; set; }
    public int? Nomination { get; set; }
    public string? Plot { get; set; }
    public string? Storyline { get; set; }
    public decimal? Budget { get; set; }
    public string? PersianStoryline { get; set; }
    public int? TopRank { get; set; }
    public byte? OscarWins { get; set; }
    public byte? OscarNominations { get; set; }
    public double? Popularity { get; set; }
    public decimal? Revenue { get; set; }
    public byte? RevenueCurrencyId { get; set; }
    public string? TrailerUrl { get; set; }
    public long? PosterPathFileId { get; set; }
    public long? BackdropPathFileId { get; set; }
    public byte? BudgetCurrencyId { get; set; }
    public bool? IsTvShow { get; set; }
    public int? CollectionId { get; set; }
    public Certificate? Certificate { get; set; }
    public Currency? RevenueCurrency { get; set; }
    public Currency? BudgetCurrency { get; set; }
    public Collection? Collection { get; set; }
    public ICollection<MovieCompany> movieCompanies { get; set; } = [];
    public ICollection<MovieCountry> movieCountries { get; set; } = [];
    public ICollection<MovieCredit> movieCredits { get; set; } = [];
    public ICollection<MovieGenre> movieGenres { get; set; } = [];
    public ICollection<MovieKeyword> movieKeywords { get; set; } = [];
    public ICollection<MovieLocation> movieLocations { get; set; } = [];
    public ICollection<MovieTagline> movieTaglines { get; set; } = [];
}