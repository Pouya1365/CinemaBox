using CinemaBox.Domain.Entertainment.Link.MovieSpokenLanguages;
using CinemaBox.Domain.Shared.Languages;
using CinemaBox.Service.Interface.Entertainment.Link.MovieSpokenLanguages;
using CinemaBox.Service.Interface.Shared.Languages;
using CinemaBox.UnitOfWork.Interface.UOW;

namespace CinemaBox.Service.Entertainment.Link.MovieSpokenLanguages;

public class MovieSpokenLanguageServices(IUnitOfWork unitOfWork, ILanguageServices LanguageServices) : IMovieSpokenLanguageServices
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    private readonly ILanguageServices _LanguageServices = LanguageServices ?? throw new ArgumentNullException(nameof(LanguageServices));
    public async Task<List<MovieSpokenLanguage>> CreateOrGetMovieLanguage(Dictionary<string, string> LanguagekeyValuePairs, string movieId)
    {
        List<MovieSpokenLanguage> movieSpokenLanguage = [];
        foreach (var LanguagekeyValuePair in LanguagekeyValuePairs)
        {
            Language language = await GetCountryPartAsync(languageName: LanguagekeyValuePair.Value,isoCode:LanguagekeyValuePair.Key);
            if (language != null)
                movieSpokenLanguage.Add(new MovieSpokenLanguage
                {
                    LanguageId = language.Id,
                    MovieId = movieId
                });
        }
        await _unitOfWork.Repository<MovieSpokenLanguage>().AddRangeAsync(movieSpokenLanguage);
        await _unitOfWork.CompleteAsync();
        return movieSpokenLanguage;
    }
    public async Task<Language> GetCountryPartAsync(string languageName,string isoCode) => await _LanguageServices.CreateOrGetLanguageAsync(LanguageName: languageName, isoCode: isoCode);
}