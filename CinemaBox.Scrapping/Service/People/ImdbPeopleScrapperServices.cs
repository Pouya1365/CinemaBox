using CinemaBox.Model.Entertainment.People;
using CinemaBox.Scrapping.Imdb.PeopleExtractors;
using CinemaBox.Scrapping.Interface.Imdb.PeopleExtractors;
using CinemaBox.Scrapping.Interface.Imdb.Service.People;
using CinemaBox.Utilities.Imdb.Json;
using CinemaBox.Utilities.Imdb.Url;
using CinemaBox.Utilities.Loader;
using HtmlAgilityPack;
using System.Text.Json;

namespace CinemaBox.Scrapping.Service.People;

public class ImdbPeopleScrapperServices: IImdbPeopleScrapperServices
{
    public async Task<PeopleModelScrapping> ImdbPeopleScrapperServicesAsync(string imdbId)
    {
        string url = ImdbUrlBuilder.BuildNameUrl(imdbId: imdbId, path: "bio");
        HtmlDocument loader = await HtmlLoader.LoadDocumentAsync(url: url);
        JsonDocument? jsonDocument = NextDataJsonParser.Parse(document: loader);
        PeopleModelScrapping peopleModelScrapping = new() { ImdbId = imdbId };
        List<IPeopleGeneralInfoExtractor> extractorsFromMainJson =
            [
            new GeneralInfoExtractor(),
            new BornExtractor(),
            new DeathExtractor(),
            new NickNameExtractor(),
            ];
        foreach (IPeopleGeneralInfoExtractor extractor in extractorsFromMainJson)
            peopleModelScrapping = extractor.Extract(model: peopleModelScrapping, json: jsonDocument);
        return peopleModelScrapping;
    }
}