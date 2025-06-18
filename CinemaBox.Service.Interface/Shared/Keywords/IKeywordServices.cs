using CinemaBox.Domain.Shared.Keywords;

namespace CinemaBox.Service.Interface.Shared.Keywords;

public interface IKeywordServices
{
    Task<Keyword?> CreateOrGetKeywordAsync(string? keywordName);
    Task<Keyword?> GetKeywordAsync(string keywordName);
}
