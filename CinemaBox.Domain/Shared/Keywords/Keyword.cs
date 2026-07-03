using CinemaBox.Domain.Entertainment.Link.MovieKeywords;
using CinemaBox.Domain.Persistent;

namespace CinemaBox.Domain.Shared.Keywords;

public class Keyword : PersistentObject<int>
{
    public required string KeywordName { get; set; }
    public string?PersianKeywordName { get; set; }
    public int? TmdbId { get; set; }
    public string? ImdbId { get; set; }
    public ICollection<MovieKeyword> MovieKeywords { get; set; } = [];
}