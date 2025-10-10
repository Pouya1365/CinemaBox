using CinemaBox.Enumeration.Entertainment.Crew;
using CinemaBox.Model.Entertainment.Cast;
using CinemaBox.Model.Entertainment.Cast.Credit;
using CinemaBox.Model.Entertainment.Movie.Movie;
using CinemaBox.Scrapping.Interface.Imdb.MovieExtractors;
using CinemaBox.Utilities.Html;
using CinemaBox.Utilities.Json;
using System.Text.Json;

namespace CinemaBox.Scrapping.Imdb.MovieExtractors;

public class CreditExtractor : IMovieGeneralInfoExtractor
{
    public MovieModelScrapping Extract(MovieModelScrapping model, JsonDocument json)
    {
        model.Credits = [];
        int leadCount = 0;

        // 🟡 مسیر قدیمی: creditCategories
        JsonElement? data = json.RootElement
            .GetPropertySafe("props")?
            .GetPropertySafe("pageProps")?
            .GetPropertySafe("contentData")?
            .GetPropertySafe("data")?
            .GetPropertySafe("title")?
            .GetPropertySafe("creditCategories");

        if (data is not null && data?.ValueKind == JsonValueKind.Array && data?.GetArrayLength() > 0)
        {
            foreach (JsonElement category in data.Value.EnumerateArray())
            {
                string? categoryId = category.GetPropertySafe("category")?.GetPropertySafe("id")?.GetString();
                if (!Enum.TryParse(categoryId, ignoreCase: true, out CreditEnumeration creditType))
                    continue;

                JsonElement? credits = category.GetPropertySafe("credits")?.GetPropertySafe("edges");
                if (credits is null || credits?.ValueKind != JsonValueKind.Array)
                    continue;

                foreach (JsonElement credit in credits.Value.EnumerateArray())
                {
                    string? name = credit.GetPropertySafe("node")
                                         ?.GetPropertySafe("name")
                                         ?.GetPropertySafe("nameText")
                                         ?.GetPropertySafe("text")
                                         ?.GetString();
                    if (string.IsNullOrWhiteSpace(name))
                        continue;

                    string? imdbId = credit.GetPropertySafe("node")
                                           ?.GetPropertySafe("name")
                                           ?.GetPropertySafe("id")
                                           ?.GetString();

                    string? imageUrl = credit.GetPropertySafe("node")
                                             ?.GetPropertySafe("name")
                                             ?.GetPropertySafe("primaryImage")
                                             ?.GetPropertySafe("url")
                                             ?.GetString();

                    string? roleName = GetRoleNames(credit);
                    roleName = string.IsNullOrWhiteSpace(roleName) ? null : HtmlDecode.HtmlDecoding(roleName);

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
        }

        // 🟢 مسیر جدید: creditGroupings (در صورتی که مسیر قدیمی خالی بود)
        if (model.Credits.Count == 0)
        {
            JsonElement? groupings = json.RootElement
                .GetPropertySafe("props")?
                .GetPropertySafe("pageProps")?
                .GetPropertySafe("contentData")?
                .GetPropertySafe("data")?
                .GetPropertySafe("title")?
                .GetPropertySafe("creditGroupings")?
                .GetPropertySafe("edges");

            if (groupings is not null && groupings?.ValueKind == JsonValueKind.Array)
            {
                foreach (JsonElement grouping in groupings.Value.EnumerateArray())
                {
                    JsonElement? node = grouping.GetPropertySafe("node");
                    if (node is null) continue;

                    string? creditTypeText = node.GetPropertySafe("grouping")?.GetPropertySafe("text")?.GetString();
                    bool isCast = string.Equals(creditTypeText, "Cast", StringComparison.OrdinalIgnoreCase);
                    string? categoryId = creditTypeText.ToLower()=="writers"?"Writer": creditTypeText.ToLower()== "producers"? "producer": creditTypeText;
                    if (!Enum.TryParse(categoryId, ignoreCase: true, out CreditEnumeration creditType))
                        continue;
                    JsonElement? credits = node.GetPropertySafe("credits")?.GetPropertySafe("edges");
                    if (credits is null || credits?.ValueKind != JsonValueKind.Array)
                        continue;

                    foreach (JsonElement credit in credits.Value.EnumerateArray())
                    {
                        JsonElement? creditNode = credit.GetPropertySafe("node");
                        if (creditNode is null) continue;

                        string? name = creditNode.GetPropertySafe("name")
                                                 ?.GetPropertySafe("nameText")
                                                 ?.GetPropertySafe("text")
                                                 ?.GetString();
                        if (string.IsNullOrWhiteSpace(name))
                            continue;

                        string? imdbId = creditNode.GetPropertySafe("name")?.GetPropertySafe("id")?.GetString();
                        string? imageUrl = creditNode.GetPropertySafe("name")
                                                     ?.GetPropertySafe("primaryImage")
                                                     ?.GetPropertySafe("url")
                                                     ?.GetString();

                        string? roleName = GetRoleNames(credit);
                        roleName = string.IsNullOrWhiteSpace(roleName) ? null : HtmlDecode.HtmlDecoding(roleName);

                        model.Credits.Add(new CreditModel
                        {
                            CreditType = categoryId,
                            EnFullName = name,
                            ImdbId = imdbId,
                            Role = roleName,
                            ImageUrl = imageUrl,
                            MovieId = model.ImdbId,
                            IsLead = isCast && leadCount < 3
                        });

                        if (isCast)
                            leadCount++;
                    }
                }
            }
        }

        return model;
    }

    public static string GetRoleNames(JsonElement credit)
    {
        try
        {
            JsonElement? roles = credit
                .GetPropertySafe("node")?
                .GetPropertySafe("creditedRoles")?
                .GetPropertySafe("edges");

            if (roles is null || roles?.ValueKind != JsonValueKind.Array)
                return string.Empty;

            List<string> roleNames = [];

            foreach (JsonElement roleEdge in roles.Value.EnumerateArray())
            {
                JsonElement? chars = roleEdge
                    .GetPropertySafe("node")?
                    .GetPropertySafe("characters")?
                    .GetPropertySafe("edges");

                if (chars is null || chars?.ValueKind != JsonValueKind.Array)
                    continue;

                foreach (JsonElement ch in chars.Value.EnumerateArray())
                {
                    string? name = ch
                        .GetPropertySafe("node")?
                        .GetPropertySafe("name")?
                        .GetString();

                    if (!string.IsNullOrWhiteSpace(name))
                        roleNames.Add(name);
                }
            }

            return string.Join(" / ", roleNames);
        }
        catch
        {
            return string.Empty;
        }
    }

}
