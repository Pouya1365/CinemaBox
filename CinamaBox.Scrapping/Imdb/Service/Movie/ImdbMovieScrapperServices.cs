namespace CinamaBox.Scrapping.Imdb.Service.Movie;

public class ImdbMovieScrapperServices
{
    public async Task<MovieModelScrapping> ScrapeAsync(string imdbId)
    {
        var json = await JsonLoader.LoadImdbJsonAsync(imdbId);
        var movie = new MovieModel();

        movie.Title = TitleExtractor.Extract(json);
        movie.Runtime = RuntimeExtractor.Extract(json);
        movie.Countries = CountryExtractor.Extract(json);
        movie.Credits = CreditExtractor.Extract(json);
        movie.Locations = LocationExtractor.Extract(json);
        movie.ProductionCompanies = CompanyExtractor.Extract(json);
        movie.Taglines = TaglineExtractor.Extract(json);
        movie.Keywords = KeywordExtractor.Extract(json);
        movie.Budget = BudgetExtractor.Extract(json);
        movie.Awards = AwardExtractor.Extract(json);

        return movie;
    }
}
