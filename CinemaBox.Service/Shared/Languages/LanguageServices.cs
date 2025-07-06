using CinemaBox.Domain.Shared.Languages;
using CinemaBox.Service.Interface.Shared.Languages;
using CinemaBox.UnitOfWork.Interface.UOW;
using Microsoft.EntityFrameworkCore;
using System;

namespace CinemaBox.Service.Shared.Languages;

public class LanguageServices(IUnitOfWork unitOfWork) : ILanguageServices
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    public async Task<Language?> CreateOrGetLanguageAsync(string? languageName, string? isoCode)
    {
        if (string.IsNullOrWhiteSpace(languageName))
            return null;
        Language? language = await GetLanguageAsync(languageName: languageName);
        if (language == null)
        {
            language = new Language { EnLanguageName = languageName.Trim(), IsoCode = isoCode };
            await _unitOfWork.Repository<Language>().AddAsync(language);
            await _unitOfWork.CompleteAsync();
        }
        return language;
    }
    public async Task<Language?> GetLanguageAsync(string languageName)
    {
        if (string.IsNullOrWhiteSpace(languageName))
            return null;

        return await _unitOfWork.Repository<Language>()
            .FindAsync(l => l.EnLanguageName == languageName || l.FaLanguageName == languageName || l.IsoCode == languageName);
    }

    public async Task<List<Language>?> GetAllLanguageFaNull() => await _unitOfWork.Repository<Language>()
            .GetAllListAsync(l => l.FaLanguageName == null);
    public async Task UpdateFaLanguge(List<Language> languages)
    {
        foreach (Language lang in languages)
            _unitOfWork.Repository<Language>().Update(lang);
        if (languages.Any())
            await _unitOfWork.CompleteAsync();
    }
}
