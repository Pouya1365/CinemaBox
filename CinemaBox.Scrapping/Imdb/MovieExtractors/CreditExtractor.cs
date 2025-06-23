using CinemaBox.Enumeration.Entertainment.Crew;
using CinemaBox.Model.Entertainment.Cast;
using CinemaBox.Model.Entertainment.Cast.Credit;
using CinemaBox.Model.Entertainment.Movie.Movie;
using CinemaBox.Scrapping.Interface.Imdb.MovieExtractors;
using CinemaBox.Utilities.Json;
using System.Text.Json;

namespace CinemaBox.Scrapping.Imdb.MovieExtractors;

public class CreditExtractor : IMovieGeneralInfoExtractor
{
    public MovieModelScrapping Extract(MovieModelScrapping model, JsonDocument json)
    {
        model.Credits = [];
        JsonElement? data = json.RootElement.GetPropertySafe("props")?
          .GetPropertySafe("pageProps")?
          .GetPropertySafe("contentData")
          .GetPropertySafe("data")
          .GetPropertySafe("title")
          .GetPropertySafe("creditCategories");
        int leadCount = 0;
        foreach (var category in data.Value.EnumerateArray())
        {
            string? categoryId = category.GetPropertySafe("category")?.GetPropertySafe("id")?.GetString();

            if (!Enum.TryParse(categoryId, ignoreCase: true, out CreditEnumeration creditType))
                continue;
            JsonElement? credits = category.GetPropertySafe("credits").GetPropertySafe("edges");
            foreach (var credit in credits.Value.EnumerateArray())
            {
                string? name = credit.GetPropertySafe("node").GetPropertySafe("name").GetPropertySafe("nameText").GetPropertySafe("text")?.GetString();
                if (string.IsNullOrWhiteSpace(name))
                    continue;
                string? imdbId = credit.GetPropertySafe("node").GetPropertySafe("name").GetPropertySafe("id")?.GetString();
                string? imageUrl = null;
                imageUrl = credit.GetPropertySafe("node").GetPropertySafe("name").GetPropertySafe("primaryImage").GetPropertySafe("url")?.GetString();
                // شخصیت‌ها
                string? roleName = GetRoleNames(credit) == "" ? null : GetRoleNames(credit);

                model.Credits.Add(new CreditModel
                {
                    CreditType = categoryId,
                    EnFullName = name,
                    ImdbId = imdbId,
                    Role = roleName,
                    ImageUrl = imageUrl,
                    MovieId = model.ImdbId,
                    IsLead = creditType == CreditEnumeration.Cast && leadCount < 3
                });

                if (creditType == CreditEnumeration.Cast)
                    leadCount++;
            }
        }

        return model;
    }
    public static string GetRoleNames(JsonElement credit)
    {

        JsonElement? data = credit.GetPropertySafe("node").GetPropertySafe("characters");
        List<string> names = [];
        if (data != null)
            foreach (var charItem in data.Value.EnumerateArray())
            {
                string? charName = charItem.GetPropertySafe("name")?.GetString();
                if (charName != null)
                    names.Add(charName);
            }
        return string.Join(" / ", names);
    }
}
