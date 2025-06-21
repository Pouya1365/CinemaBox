using CinemaBox.Model.Entertainment.Movie.Movie;
using CinemaBox.Scrapping.Interface.Imdb.MovieExtractors;
using CinemaBox.Utilities.Json;
using System.Text.Json;

namespace CinemaBox.Scrapping.Imdb.MovieExtractors;

public class SpokenLanguagesExtractor : IMovieGeneralInfoExtractor
{
    public MovieModelScrapping Extract(MovieModelScrapping model, JsonDocument json)
    {
        model.SpokenLanguageskeyValuePairs = [];
        JsonElement? data = json.RootElement.GetPropertySafe("props")?
      .GetPropertySafe("pageProps")?
      .GetPropertySafe("mainColumnData");
        JsonElement? spokenLanguages = data.GetPropertySafe("spokenLanguages").GetPropertySafe("spokenLanguages");
        foreach ((string id, string text) in from JsonElement spokenLanguageitem in spokenLanguages.Value.EnumerateArray()
                                             let id = spokenLanguageitem.GetProperty("id").GetString()
                                             where !string.IsNullOrEmpty(id)
                                             let text = spokenLanguageitem.GetProperty("text").GetString()
                                             select (id, text))
            model.SpokenLanguageskeyValuePairs.Add(id, text);
        return model;
    }
}