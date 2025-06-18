using CinemaBox.Domain.Entertainment.Link.MovieKeywords;
using CinemaBox.Domain.Shared.Keywords;
using CinemaBox.Service.Interface.Entertainment.Link.MovieKeywords;
using CinemaBox.Service.Interface.Shared.Keywords;

using CinemaBox.UnitOfWork.Interface.UOW;

namespace CinemaBox.Service.Entertainment.Link.MovieKeywords;

public class MovieKeywordServices(IUnitOfWork unitOfWork, IKeywordServices keywordServices) : IMovieKeywordServices
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    private readonly IKeywordServices _keywordServices = keywordServices ?? throw new ArgumentNullException(nameof(keywordServices));
    public async Task<List<MovieKeyword>> CreateOrGetMovieKeyword(Dictionary<string,string> keywordkeyValuePairs, string movieId)
    {
        List<MovieKeyword> MovieKeyword = [];
        foreach (var keywordkeyValuePair in keywordkeyValuePairs)
        {
            Keyword? keyword = await GetKeywordAsync(keywordId: keywordkeyValuePair.Key, keywordName: keywordkeyValuePair.Value);
            if (keyword != null)
                MovieKeyword.Add(new MovieKeyword
                {
                    KeywordId = keyword.Id,
                    MovieId = movieId
                });
        }
        await _unitOfWork.Repository<MovieKeyword>().AddRangeAsync(MovieKeyword);
        await _unitOfWork.CompleteAsync();
        return MovieKeyword;
    }
    public async Task<Keyword?> GetKeywordAsync(string? keywordId, string? keywordName) => await _keywordServices.CreateOrGetKeywordAsync(keywordId: keywordId, keywordName: keywordName);
}