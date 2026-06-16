using CinemaBox.Model.Entertainment.Movie.Movie;
using CinemaBox.Scrapping.Interface.Imdb.MovieExtractors;
using CinemaBox.Utilities.Json;
using System.Text.Json;
using System.Linq;

namespace CinemaBox.Scrapping.Imdb.MovieExtractors;

public class KeywordsExtractor : IMovieGeneralInfoExtractor
{
    public MovieModelScrapping Extract(MovieModelScrapping model, JsonDocument json)
    {
        JsonElement? data = json.RootElement
    .GetProperty("props")
    .GetProperty("pageProps")
    .GetProperty("contentData")
    .GetProperty("data")
    .GetProperty("title")
    .GetProperty("keywordItemCategories");

        model.KeywordskeyValuePairs = [];
        foreach (var (id, text) in from JsonElement category in data?.EnumerateArray()
                                   from JsonElement edge in category.GetProperty("keywords").GetProperty("edges").EnumerateArray()
                                   let keyword = edge.GetProperty("node").GetProperty("keyword")
                                   let id = keyword.GetProperty("id").GetString()!
                                   let text = keyword.GetProperty("text").GetProperty("text").GetString()!
                                   select (id, text))
     
            model.KeywordskeyValuePairs.Add(id, text);
       

        return model;
    }
}


