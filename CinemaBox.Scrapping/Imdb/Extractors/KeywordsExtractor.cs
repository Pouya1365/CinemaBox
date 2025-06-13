using CinemaBox.Model.Imdb.Movie;
using CinemaBox.Scrapping.Interface.Imdb.Extractors;
using CinemaBox.Utilities.Json;
using System.Text.Json;

namespace CinemaBox.Scrapping.Imdb.Extractors;

public class KeywordsExtractor : IGeneralInfoExtractor
{
    public MovieModelScrapping Extract(MovieModelScrapping model, JsonDocument json)
    {
        JsonElement? data = json.RootElement.GetPropertySafe("props")?
          .GetPropertySafe("pageProps")?
          .GetPropertySafe("contentData")
          .GetPropertySafe("data")
          .GetPropertySafe("title")
          .GetPropertySafe("keywords")
          .GetPropertySafe("edges");
        model.KeywordskeyValuePairs = [];

        foreach (var (id, text) in from JsonElement edge in data.Value.EnumerateArray()
                                   let id = edge.GetProperty("node").GetProperty("keyword").GetProperty("id").GetString()
                                   let text = edge.GetProperty("node").GetProperty("keyword").GetProperty("text").GetProperty("text").GetString()
                                   select (id, text))
            model.KeywordskeyValuePairs.Add(id, text);

        return model;
    }
}

