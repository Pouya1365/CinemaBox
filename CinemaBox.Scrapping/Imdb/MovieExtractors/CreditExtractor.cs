using CinemaBox.Enumeration.Entertainment.Crew;
using CinemaBox.Model.Entertainment.Cast;
using CinemaBox.Model.Entertainment.Cast.Credit;
using CinemaBox.Model.Entertainment.Movie.Movie;
using CinemaBox.Scrapping.Interface.Imdb.MovieExtractors;
using CinemaBox.Utilities.Html;
using CinemaBox.Utilities.Json;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Xml.Linq;

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
        JsonElement? castEdges = json.RootElement
       .GetPropertySafe("data")?
       .GetPropertySafe("title")?
       .GetPropertySafe("creditGroupings")?
       .GetPropertySafe("edges");

        if (castEdges is not null && castEdges?.ValueKind == JsonValueKind.Array)
        {
            Debug.WriteLine($"🎬 پیدا کردن بازیگران در castPageTitle: {castEdges.Value.GetArrayLength()} نفر");

            foreach (JsonElement castEdge in castEdges.Value.EnumerateArray())
            {
                string? name = castEdge.GetPropertySafe("node")?
                                      .GetPropertySafe("name")?
                                      .GetPropertySafe("nameText")?
                                      .GetPropertySafe("text")?
                                      .GetString();

                if (string.IsNullOrWhiteSpace(name))
                    continue;

                string? imdbId = castEdge.GetPropertySafe("node")?
                                        .GetPropertySafe("name")?
                                        .GetPropertySafe("id")?
                                        .GetString();

                // برای نقش‌ها باید به بخش کامل‌تر Cast در creditGroupings مراجعه کنیم
                string? roleName = GetRoleNames(castEdge);
                roleName = string.IsNullOrWhiteSpace(roleName) ? null : HtmlDecode.HtmlDecoding(roleName);
                bool alreadyExists = model.Credits.Any(c =>
                          c.ImdbId == imdbId && c.CreditType == "Cast");

                if (!alreadyExists)
                {
                    model.Credits.Add(new CreditModel
                    {
                        CreditType = "Cast",
                        EnFullName = name,
                        ImdbId = imdbId,
                        Role = roleName,
                        ImageUrl = null, // از بخش دیگر قابل استخراج است
                        MovieId = model.ImdbId,
                        IsLead = leadCount < 3 // تعداد بیشتری را بعنوان نقش اصلی در نظر بگیرید
                    });

                    leadCount++;
                }
            }
        }
        // ادامه از props -> pageProps
        var pageProps = json.RootElement.GetPropertySafe("props").GetPropertySafe("pageProps").GetPropertySafe("contentData").GetPropertySafe("categories");


        foreach (var category in pageProps.Value.EnumerateArray())
        {
            if (category.TryGetProperty("name", out var categoryName) &&
                categoryName.GetString() == "Cast")
            {
                var items = category.GetProperty("section").GetProperty("items");

                foreach (var item in items.EnumerateArray())
                {
                    var name = item.GetProperty("rowTitle").GetString();
                    var imdbId = item.GetProperty("id").GetString(); // از property "id"
                    var isCast = item.GetProperty("isCast").GetBoolean();

                    // گرفتن نقش (character)
                    string roleName = null;
                    if (item.TryGetProperty("characters", out var characters) &&
                        characters.GetArrayLength() > 0)
                    {
                        roleName = characters[0].GetString(); // اولین نقش
                    }

                    // گرفتن عکس
                    string imageUrl = null;
                    if (item.TryGetProperty("imageProps", out var imageProps) &&
                        imageProps.TryGetProperty("imageModel", out var imageModel) &&
                        imageModel.TryGetProperty("url", out var url))
                    {
                        imageUrl = url.GetString();
                    }


                    bool alreadyExists = model.Credits.Any(c =>
                                            c.ImdbId == imdbId && c.CreditType == "Cast");

                    if (!alreadyExists)
                    {
                        model.Credits.Add(new CreditModel
                        {
                            CreditType = "Cast",
                            EnFullName = name,
                            ImdbId = imdbId,
                            Role = roleName,
                            ImageUrl = imageUrl,
                            MovieId = model.ImdbId, // از مدل اصلی
                            IsLead = leadCount < 3 // ۵ نفر اول را بعنوان نقش اصلی در نظر بگیر
                        });
                    }
                }
            }
            // 🟢 مسیر جدید: creditGroupings (در صورتی که مسیر قدیمی خالی بود)

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
                Debug.WriteLine($"🔍 مسیر جدید: {groupings.Value.GetArrayLength()} گروه پیدا شد");

                foreach (JsonElement grouping in groupings.Value.EnumerateArray())
                {
                    JsonElement? node = grouping.GetPropertySafe("node");
                    if (node is null) continue;

                    string? creditTypeText = node.GetPropertySafe("grouping")?.GetPropertySafe("text")?.GetString();
                    Debug.WriteLine($"🎬 پردازش گروه: {creditTypeText}");

                    bool isCast = string.Equals(creditTypeText, "Cast", StringComparison.OrdinalIgnoreCase);
                    string? categoryId = creditTypeText?.ToLower() == "writers" ? "Writer" :
                                       creditTypeText?.ToLower() == "producers" ? "Producer" :
                                       creditTypeText;

                    if (!Enum.TryParse(categoryId, ignoreCase: true, out CreditEnumeration creditType))
                    {
                        Debug.WriteLine($"⚠️ نتوانستیم {categoryId} را به enum تبدیل کنیم");
                        continue;
                    }

                    JsonElement? credits = node.GetPropertySafe("credits")?.GetPropertySafe("edges");
                    if (credits is null || credits?.ValueKind != JsonValueKind.Array)
                        continue;

                    Debug.WriteLine($"👥 در گروه {creditTypeText}: {credits.Value.GetArrayLength()} نفر پیدا شد");

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

                        // 🔍 چک کنیم آیا ناتالی پورتمن هست یا نه
                        bool isNataliePortman = name.Contains("Natalie Portman", StringComparison.OrdinalIgnoreCase);
                        if (isNataliePortman)
                        {
                            Debug.WriteLine($"🎉 ناتالی پورتمن پیدا شد! در گروه: {creditTypeText}");
                        }

                        string? imdbId = creditNode.GetPropertySafe("name")?.GetPropertySafe("id")?.GetString();
                        string? imageUrl = creditNode.GetPropertySafe("name")
                                                     ?.GetPropertySafe("primaryImage")
                                                     ?.GetPropertySafe("url")
                                                     ?.GetString();

                        string? roleName = GetRoleNames(credit);
                        roleName = string.IsNullOrWhiteSpace(roleName) ? null : HtmlDecode.HtmlDecoding(roleName);

                        if (isNataliePortman)
                        {
                            Debug.WriteLine($"🎭 نقش ناتالی پورتمن: {roleName}");
                        }

                        // ✅ بررسی کنیم آیا این شخص از قبل اضافه شده یا نه
                        bool alreadyExists = model.Credits.Any(c =>
                            c.ImdbId == imdbId && c.CreditType == categoryId);

                        if (!alreadyExists)
                        {
                            model.Credits.Add(new CreditModel
                            {
                                CreditType = categoryId,
                                EnFullName = name,
                                ImdbId = imdbId,
                                Role = roleName,
                                ImageUrl = imageUrl,
                                MovieId = model.ImdbId,
                                IsLead = isCast && leadCount < 3 // 🟢 تعداد را افزایش دهید
                            });
                            if (isCast)
                                leadCount++;
                        }
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
