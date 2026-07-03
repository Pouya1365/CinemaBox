using CinemaBox.Domain.Entertainment.Movies;
using CinemaBox.Domain.Shared.Keywords;

namespace CinemaBox.Domain.Entertainment.Link.MovieKeywords;

public class MovieKeyword
{
    public required int MovieId { get; set; }
    public required int KeywordId { get; set; }
    public Keyword? Keyword { get; set; }
    public Movie? Movie { get; set; }
}