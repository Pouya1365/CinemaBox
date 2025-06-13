using CinemaBox.Model.Imdb.Movie;
using CinemaBox.Scrapping.Interface.Imdb.Extractors;
using CinemaBox.Utilities.Json;
using System.Text.Json;

namespace CinemaBox.Scrapping.Imdb.Extractors;

public class AggregateVotingExtractor : IGeneralInfoExtractor
{
    public MovieModelScrapping Extract(MovieModelScrapping model, JsonDocument json)
    {
        JsonElement? data = json.RootElement.GetPropertySafe("props")?
          .GetPropertySafe("pageProps")?
          .GetPropertySafe("aboveTheFoldData");
        model.AggregateRating = data.GetPropertySafe("ratingsSummary").GetPropertySafe("aggregateRating")?.GetDecimal();
        model.VoteCount = data.GetPropertySafe("ratingsSummary").GetPropertySafe("voteCount")?.GetInt64();
        return model;
    }
}
