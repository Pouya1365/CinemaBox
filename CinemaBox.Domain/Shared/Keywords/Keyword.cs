using CinemaBox.Domain.Entertainment.Link.MovieKeywords;
using CinemaBox.Domain.Persistent;

namespace CinemaBox.Domain.Shared.Keywords;

public class Keyword : PersistentObject<string>
{
    public required string EnKeywordName { get; set; }
    public string? FaKeywordName { get; set; }
    public ICollection<MovieKeyword> MovieKeywords { get; set; } = [];
}