using CinemaBox.Model.Entertainment.Movie.Movie;
using CinemaBox.Scrapping.Imdb.MovieExtractors;
using CinemaBox.Scrapping.Interface.Imdb.MovieExtractors;
using CinemaBox.Scrapping.Interface.Imdb.Service.Movie;
using CinemaBox.Utilities.Imdb.Url;
using CinemaBox.Utilities.Loader;

namespace CinemaBox.Scrapping.Service.Movie;

public class ImdbOtherScrapperServices : IImdbOtherScrapperServices
{
    public async Task<MovieModelScrapping> ImdbScrapperServicesAsync(MovieModelScrapping movieModel)
    {
        (string Path, IOtherCrewsExtractor Extractor)[] extractorsWithPaths =
             [
                 ("fullcredits", new OtherCrewsExtractor()),
             ];
        foreach ((string path, IOtherCrewsExtractor extractor) in extractorsWithPaths)
        {
            string url = ImdbUrlBuilder.BuildTitleUrl(imdbId: movieModel.ImdbId, path: path);
            HtmlAgilityPack.HtmlDocument? loader = await HtmlLoader.LoadDocumentAsync(url: url);
            movieModel = extractor.Extract(model: movieModel, document: loader);
        }
        return movieModel;
    }
}
