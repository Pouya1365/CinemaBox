using CinemaBox.Domain.Entertainment.Link.MovieKeywords;
using CinemaBox.Domain.Shared.Keywords;

namespace CinemaBox.Service.Interface.Entertainment.Link.MovieKeywords;

public interface IMovieKeywordServices
{
    Task<List<MovieKeyword>> CreateOrGetMovieKeyword(Dictionary<string, string> keywordkeyValuePairs, string movieId);
    Task<Keyword?> GetKeywordAsync(string? keywordId, string? keywordName);
    Task<IEnumerable<MovieKeyword?>> GetMovieKeywordAsync(string? movieId);
}
