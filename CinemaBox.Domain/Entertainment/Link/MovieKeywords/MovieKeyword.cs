using CinemaBox.Domain.Entertainment.Movies;
using CinemaBox.Domain.Shared.Keywords;

namespace CinemaBox.Domain.Entertainment.Link.MovieKeywords;

public class MovieKeyword
{
    public required string MovieId { get; set; }
    public required string KeywordId { get; set; }
    public Keyword? Keyword { get; set; }
    public Movie? Movie { get; set; }
}