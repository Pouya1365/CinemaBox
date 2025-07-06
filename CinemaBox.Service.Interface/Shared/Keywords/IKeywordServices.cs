using CinemaBox.Domain.Shared.Keywords;

namespace CinemaBox.Service.Interface.Shared.Keywords;

public interface IKeywordServices
{
    Task<Keyword?> CreateOrGetKeywordAsync(string? keywordId, string? keywordName);
    Task<Keyword?> GetKeywordAsync(string keywordName);
    Task<List<Keyword>?> GetKeywordFaNulllAsync();
    Task UpdateKeyword(List<Keyword>? keywords);
}
