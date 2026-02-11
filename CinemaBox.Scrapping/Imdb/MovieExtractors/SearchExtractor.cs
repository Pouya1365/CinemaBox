using CinemaBox.Model.Entertainment.Movie.ShowMovie;
using CinemaBox.Scrapping.Interface.Imdb.MovieExtractors;
using CinemaBox.Utilities.Json;
using System.Text.Json;

namespace CinemaBox.Scrapping.Imdb.MovieExtractors;

public class SearchExtractor: IMovieSearchExtractor
{
    public List<ShowMovieModel> Extract(JsonDocument document)
    {
        List<ShowMovieModel> movies = [];

        try
        {          
            JsonElement root = document.RootElement;
            // استخراج فیلم‌ها از titleResults
            JsonElement? titleResults = root
                .GetPropertySafe("props")?
                .GetPropertySafe("pageProps")?
                .GetPropertySafe("titleResults")?
                .GetPropertySafe("results");
            if (titleResults is not null && titleResults?.ValueKind == JsonValueKind.Array)                                
                foreach (JsonElement item in titleResults.Value.EnumerateArray())
                {
                    var movie = ExtractMovieInfo(item);
                    if (movie?.EnTitle != null)
                        movies.Add(movie);
                }                
            Console.WriteLine("\nپردازش با موفقیت انجام شد!");        
        }
        catch (Exception ex)
        {
            Console.WriteLine($"خطا: {ex.Message}");
        }
        return movies;
    }
    static ShowMovieModel? ExtractMovieInfo(JsonElement item)
    {
        JsonElement? listItem = item.GetPropertySafe("listItem");
        if (listItem is null)
            return null;
        ShowMovieModel movie = new()
        {
            MovieId = listItem?.GetPropertySafe("titleId")?.GetString() ??
                         item.GetPropertySafe("index")?.GetString(),
            EnTitle = listItem?.GetPropertySafe("titleText")?.GetString(),
            StartYear = listItem?.GetPropertySafe("releaseYear")?.GetInt32() ??
                       listItem?.GetPropertySafe("releaseDate")?.GetPropertySafe("year")?.GetInt32(),
            PosterPath = listItem?.GetPropertySafe("primaryImage")?.GetPropertySafe("url")?.GetString(),
        };
        return movie;
    }     
}
