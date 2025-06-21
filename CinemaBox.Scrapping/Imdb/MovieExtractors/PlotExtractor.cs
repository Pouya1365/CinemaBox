using CinemaBox.Model.Imdb.Movie;
using CinemaBox.Scrapping.Interface.Imdb.MovieExtractors;
using CinemaBox.Utilities.Html;
using CinemaBox.Utilities.Json;
using System.Text.Json;

namespace CinemaBox.Scrapping.Imdb.MovieExtractors;

public class PlotExtractor : IMovieGeneralInfoExtractor
{
    public MovieModelScrapping Extract(MovieModelScrapping model, JsonDocument json)
    {
        JsonElement? data = json.RootElement.GetPropertySafe("props")?
          .GetPropertySafe("pageProps")?
          .GetPropertySafe("contentData")
          .GetPropertySafe("data")
          .GetPropertySafe("title")
          .GetPropertySafe("plotSummaries")
          .GetPropertySafe("edges");
        var summaries = data.Value.EnumerateArray().Take(2).ToArray();
        if (summaries.Length > 0)
        {
            JsonElement? enPlot = summaries[0].GetPropertySafe("node").GetPropertySafe("plotText").GetPropertySafe("plaidHtml");
            model.EnPlot = HtmlDecode.HtmlDecoding(input: enPlot?.GetString());
        }
        if (summaries.Length > 1)
        {
            JsonElement? enStoryline = summaries[1].GetPropertySafe("node").GetPropertySafe("plotText").GetPropertySafe("plaidHtml");
            model.EnStoryline = HtmlDecode.HtmlDecoding(input: enStoryline?.GetString());
        }
        return model;
    }
}