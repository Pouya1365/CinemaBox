using CinemaBox.Domain.Entertainment.Link.MovieSpokenLanguages;
using CinemaBox.Domain.Shared.Languages;

namespace CinemaBox.Service.Interface.Entertainment.Link.MovieSpokenLanguages;

public interface IMovieSpokenLanguageServices
{
    Task<List<MovieSpokenLanguage>> CreateOrGetMovieLanguage(Dictionary<string, string> LanguagekeyValuePairs, string movieId);
    Task<Language> GetCountryPartAsync(string languageName, string isoCode);
}
