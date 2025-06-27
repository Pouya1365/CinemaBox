using CinemaBox.Model.Entertainment.Movie.Movie;
using HtmlAgilityPack;

namespace CinemaBox.Scrapping.Interface.Imdb.MovieExtractors;

public interface IOtherCrewsExtractor
{
    MovieModelScrapping Extract(MovieModelScrapping model, HtmlDocument document);
}
