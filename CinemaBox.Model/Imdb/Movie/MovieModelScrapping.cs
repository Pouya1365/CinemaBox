using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CinemaBox.Model.Imdb.Movie;

public class MovieModelScrapping
{
    public string? EnTitle { get; set; }
    public string? OriginalTitle { get; set; }
    public long? StartYear { get; set; }
    public long? RunTimeMinutes { get; set; }
    public string? ImageUrl { get; set; }
    public long? ReleaseYear { get; set; }
    public long? ReleaseMonth { get; set; }
    public long? ReleaseDay { get; set; }
    public string? Certificate { get; set; }
    public decimal? AggregateRating { get; set; }
    public long? VoteCount { get; set; }
    public long? Winner { get; set; }
    public long? Nomination { get; set; }
    public byte? TopRank { get; set; }
    public byte? OscarNominations { get; set; }
    public byte? OscarWins { get; set; }
    public List<string>? Genres { get; set; }
    public Dictionary<string,string>? CountrieskeyValuePairs { get; set; }
    public Dictionary<string,string>? SpokenLanguageskeyValuePairs { get; set; }
    public double? Budget { get; set; }
    public string? BudgetCurrency { get; set; }
}
