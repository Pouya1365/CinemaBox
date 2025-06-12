using CinemaBox.Model.Imdb.Movie;
using CinemaBox.Scrapping.Interface.Imdb.Extractors;
using CinemaBox.Utilities.Json;
using System.Text.Json;

namespace CinamaBox.Scrapping.Imdb.Extractors;

public class SpokenLanguagesExtractor : IGeneralInfoExtractor
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