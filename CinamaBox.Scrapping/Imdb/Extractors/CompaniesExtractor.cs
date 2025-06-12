using CinemaBox.Enumeration.Imdb.Company;
using CinemaBox.Model.Imdb.Movie;
using CinemaBox.Scrapping.Interface.Imdb.Extractors;
using CinemaBox.Utilities.Json;
using System.Text.Json;

namespace CinamaBox.Scrapping.Imdb.Extractors;

public class CompaniesExtractor : IGeneralInfoExtractor
{
    public MovieModelScrapping Extract(MovieModelScrapping model, JsonDocument json)
    {
        JsonElement? data = json.RootElement.GetPropertySafe("props")?
          .GetPropertySafe("pageProps")?
          .GetPropertySafe("contentData");
        model.Companies = [];
        JsonElement.ArrayEnumerator? companies = data.GetPropertySafe("data").GetPropertySafe("title").GetPropertySafe("companyCreditCategories")?.EnumerateArray();
        foreach ((JsonElement company, string companyId) in from JsonElement company in companies
                                                            let companyInfo = company.GetProperty("category")
                                                            let companyId = companyInfo.GetProperty("id").GetString()
                                                            select (company, companyId))
        {
            if (!Enum.TryParse(companyId, ignoreCase: true, out CompanyEnumeration companyEnum))
                continue;
            JsonElement companyContainer = company.GetProperty("companyCredits");
            JsonElement edges = companyContainer.GetProperty("edges");
            foreach ((string CompanyId, string CompanyName) in from JsonElement edge in edges.EnumerateArray()
                                                               let node = edge.GetProperty("node")
                                                               let companyNode = node.GetProperty("company")
                                                               let displayable = node.GetProperty("displayableProperty").GetProperty("value")
                                                               let CompanyId = companyNode.GetProperty("id").GetString()
                                                               let CompanyName = displayable.GetProperty("plainText").GetString()
                                                               select (CompanyId, CompanyName))
                model.Companies.Add(CompanyId, CompanyName);
            break;// چون فقط یکی از این دسته می‌خوایم، بعد از پیدا کردنش می‌زنیم بیرون
        }
        return model;
    }
}