using CinemaBox.Domain.Shared.Languages;

namespace CinemaBox.Service.Interface.Shared.Languages;

public interface ILanguageServices
{
    Task<Language?> CreateOrGetLanguageAsync(string? languageName, string? isoCode);
    Task<Language?> GetLanguageAsync(string languageName);
}
