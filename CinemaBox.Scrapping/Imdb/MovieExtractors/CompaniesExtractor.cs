using CinemaBox.Enumeration.Entertainment.Company;
using CinemaBox.Model.Entertainment.Movie.Movie;
using CinemaBox.Scrapping.Interface.Imdb.MovieExtractors;
using CinemaBox.Utilities.Json;
using System.Text.Json;

namespace CinemaBox.Scrapping.Imdb.MovieExtractors;

public class CompaniesExtractor : IMovieGeneralInfoExtractor
{
    public MovieModelScrapping Extract(MovieModelScrapping model, JsonDocument json)
    {
        JsonElement? data = json.RootElement
      .GetPropertySafe("props")?
      .GetPropertySafe("pageProps")?
      .GetPropertySafe("contentData");

        if (data is null)
            return model;

        JsonElement.ArrayEnumerator? companiesArrayEnumerator = data
          .GetPropertySafe("data")
          ?.GetPropertySafe("title")
          ?.GetPropertySafe("companyCreditCategories")
          ?.EnumerateArray();

        if (companiesArrayEnumerator is null)
            return model;

        model.Companies = [];
        List<JsonElement> companiesArray = companiesArrayEnumerator?.ToList() ?? [];
        // فقط اولین دسته (مثلاً Production Companies یا...) را می‌خواهیم
        JsonElement firstCompany = companiesArray
            .FirstOrDefault(company =>
            {
                JsonElement? companyInfo = company.GetPropertySafe("category");
                string? companyId = companyInfo?.GetPropertySafe("id")?.GetString();
                return companyId is not null &&
                       Enum.TryParse(companyId, ignoreCase: true, out CompanyEnumeration _);
            });

        if (firstCompany.ValueKind == JsonValueKind.Undefined)
            return model;

        JsonElement? companyContainer = firstCompany.GetPropertySafe("companyCredits");
        JsonElement? edges = companyContainer?.GetPropertySafe("edges");

        if (edges is null || edges.Value.ValueKind != JsonValueKind.Array)
            return model;

        var companyList =
            (from JsonElement edge in edges.Value.EnumerateArray()
             let node = edge.GetPropertySafe("node")
             let companyNode = node?.GetPropertySafe("company")
             let displayable = node?.GetPropertySafe("displayableProperty")?.GetPropertySafe("value")
             let newCompanyId = companyNode?.GetPropertySafe("id")?.GetString()
             let newCompanyName = displayable?.GetPropertySafe("plainText")?.GetString()
             where newCompanyId is not null && newCompanyName is not null
             group newCompanyName by newCompanyId into g
             select new
             {
                 CompanyId = g.Key,
                 CompanyName = g.First()
             }).ToList();

        foreach (var item in companyList)        
            model.Companies.Add(item.CompanyId, item.CompanyName);
        

        return model;
    }
}