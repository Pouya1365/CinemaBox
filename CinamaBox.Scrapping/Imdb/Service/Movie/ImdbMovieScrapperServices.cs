using CinamaBox.Scrapping.Imdb.Extractors;
using CinemaBox.Model.Imdb.Movie;
using CinemaBox.Scrapping.Interface.Imdb.Extractors;
using CinemaBox.Utilities.Imdb.Json;
using CinemaBox.Utilities.Imdb.Url;
using CinemaBox.Utilities.Loader;
using HtmlAgilityPack;
using System.Text.Json;

namespace CinamaBox.Scrapping.Imdb.Service.Movie;

public class ImdbMovieScrapperServices
{
    public async Task<MovieModelScrapping> ImdbScrapperServicesAsync(string imdbId)
    {
        string url = ImdbUrlBuilder.BuildTitleUrl(imdbId: imdbId, path: null);
        HtmlDocument loader = await HtmlLoader.LoadDocumentAsync(url: url);
        JsonDocument? jsonDocument = NextDataJsonParser.Parse(document: loader);
        MovieModelScrapping moviesModel = new() { ImdbId = imdbId };
        // اکسترکتورهایی که از JSON اصلی استفاده می‌کنند
        List<IGeneralInfoExtractor> extractorsFromMainJson =
        [
        new GeneralInfoExtractor(),
        new ReleaseDateExtractor(),
        new CertificateExtractor(),
        new AggregateVotingExtractor(),
        new AwardsExtractor(),
        new GenresExtractor(),
        new CountriesExtractor(),
        new SpokenLanguagesExtractor(),
        new BudgetExtractor()
    ];
        foreach (IGeneralInfoExtractor extractor in extractorsFromMainJson)
            moviesModel = extractor.Extract(model: moviesModel,json: jsonDocument);
        // اکسترکتورهایی با مسیر JSON متفاوت
        (string Path, IGeneralInfoExtractor Extractor)[] extractorsWithPaths =
        [
        ("taglines", new TaglinesExtractor()),
        ("locations", new LocationsExtractor()),
        ("companycredits", new CompaniesExtractor()),
        ("fullcredits", new CreditExtractor()),
        ("plotsummary", new PlotExtractor()),
        ("keywords", new KeywordsExtractor())
        ];
        foreach (var (path, extractor) in extractorsWithPaths)
        {
             url = ImdbUrlBuilder.BuildTitleUrl(imdbId: imdbId, path: path);
             loader = await HtmlLoader.LoadDocumentAsync(url: url);
            jsonDocument = NextDataJsonParser.Parse(document: loader);
            moviesModel = extractor.Extract(model: moviesModel, json: jsonDocument);
        }
        return moviesModel;
    }
}
