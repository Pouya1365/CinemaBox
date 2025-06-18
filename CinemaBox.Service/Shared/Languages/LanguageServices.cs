using CinemaBox.Domain.Shared.Languages;
using CinemaBox.Service.Interface.Shared.Languages;
using CinemaBox.UnitOfWork.Interface.UOW;

namespace CinemaBox.Service.Shared.Languages;

public class LanguageServices(IUnitOfWork unitOfWork) : ILanguageServices
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    public async Task<Language?> CreateOrGetLanguageAsync(string? LanguageName,string? isoCode)
    {
        if (string.IsNullOrWhiteSpace(LanguageName))
            return null;
        Language? Language = await GetLanguageAsync(languageName: LanguageName);
        if (Language == null)
        {
            Language = new Language { EnLanguageName = LanguageName.Trim() ,IsoCode= isoCode };
            await _unitOfWork.Repository<Language>().AddAsync(Language);
            await _unitOfWork.CompleteAsync();
        }
        return Language;
    }
    public async Task<Language?> GetLanguageAsync(string languageName)
    {
        if (string.IsNullOrWhiteSpace(languageName))
            return null;

        return await _unitOfWork.Repository<Language>()
            .FindAsync(l => l.EnLanguageName == languageName && l.FaLanguageName==languageName);
    }
}
