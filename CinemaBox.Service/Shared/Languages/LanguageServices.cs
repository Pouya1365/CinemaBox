using CinemaBox.Domain.Entertainment.Genres;
using CinemaBox.Domain.Shared.Languages;
using CinemaBox.Libretranslate.Interface;
using CinemaBox.Service.Interface.Shared.Languages;
using CinemaBox.UnitOfWork.Interface.UOW;
using CinemaBox.Utilities.Html;
using System;

namespace CinemaBox.Service.Shared.Languages;

public class LanguageServices(IUnitOfWork unitOfWork, ITranslate translate) : ILanguageServices
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork)); 
    private readonly ITranslate _translate = translate ?? throw new ArgumentNullException(nameof(translate));
    public async Task<Language?> CreateOrGetLanguageAsync(string? languageName, string? isoCode)
    {
        if (string.IsNullOrWhiteSpace(languageName))
            return null;
        Language? language = await GetLanguageAsync(languageName: languageName);
        if (language == null)
        {
            string faLanguageName = await GetFa(languageName: languageName);
            language = new Language { EnLanguageName = languageName.Trim(), IsoCode = isoCode,FaLanguageName=faLanguageName };
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
    private async Task<string> GetFa(string languageName) => HtmlDecode.HtmlDecoding(await _translate.TranslateText(text: languageName));
    public async Task<List<Language>?> GetAllLanguageFaNull() => await _unitOfWork.Repository<Language>()
            .GetAllListAsync(l => l.FaLanguageName == null);
    public async Task UpdateFaLanguge(List<Language> languages)
    {
        foreach (Language lang in languages)
            _unitOfWork.Repository<Language>().Update(lang);
        if (languages.Any())
            await _unitOfWork.CompleteAsync();
    }
    public async Task<Dictionary<string, int>> GetMovieCountPerLanguage()
    {
        IEnumerable<Language> languages = await _unitOfWork.Repository<Language>().GetAllWithIncludesAsync(x => x.MovieSpokenLanguages);
        return languages.Select(l => new
        {
            Name = l.FaLanguageName ?? l.EnLanguageName,
            Value = l.MovieSpokenLanguages.Count()
        })
          .OrderByDescending(x => x.Value)
          .ToDictionary(x => x.Name, x => x.Value);
    }
}
