using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CinemaBox.Model.Imdb.Movie;

public class MovieModelScrapping
{
    public string? EnTitle { get; set; }
    public string? OriginalTitle { get; set; }
    public long? StartYear { get; set; }
    public long? RunTimeMinutes { get; set; }
    public string? ImageUrl { get; set; }
    public long? ReleaseYear { get; set; }
    public long? ReleaseMonth { get; set; }
    public long? ReleaseDay { get; set; }
    public string? Certificate { get; set; }

}
