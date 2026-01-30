using CinemaBox.Model.Entertainment.Movie.Movie;
using CinemaBox.Scrapping.Interface.Imdb.MovieExtractors;
using CinemaBox.Utilities.Json;
using System.Text.Json;

namespace CinemaBox.Scrapping.Imdb.MovieExtractors;

public class AggregateVotingExtractor : IMovieGeneralInfoExtractor
{
    public MovieModelScrapping Extract(MovieModelScrapping model, JsonDocument json)
    {
        JsonElement? data = json.RootElement.GetPropertySafe("props")?
          .GetPropertySafe("pageProps")?
          .GetPropertySafe("aboveTheFoldData");
        decimal rating = 0;

        var el =
            data?
                .GetPropertySafe("ratingsSummary")?
                .GetPropertySafe("aggregateRating");

        if (el is not null)
        {
            if (el.Value.ValueKind == JsonValueKind.Number)
                rating = el.Value.GetDecimal();

            else if (el.Value.ValueKind == JsonValueKind.String &&
                     decimal.TryParse(el.Value.GetString(), out var parsed))
                rating = parsed;
        }

        model.AggregateRating = rating;
        model.VoteCount = data.GetPropertySafe("ratingsSummary").GetPropertySafe("voteCount")?.GetInt64();
        return model;
    }
}
