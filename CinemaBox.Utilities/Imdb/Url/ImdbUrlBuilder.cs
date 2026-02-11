namespace CinemaBox.Utilities.Imdb.Url;

public static class ImdbUrlBuilder
{
    public static string BuildTitleUrl(string imdbId, string? path)
    {
        string baseUrl = $"https://m.imdb.com/title/{imdbId}/";
        return string.IsNullOrEmpty(path) ? baseUrl + "?ref_=tt_rvi_t_2" : baseUrl + path;
    }

    public static string BuildNameUrl(string imdbId, string? path)
    {
        string baseUrl = $"https://m.imdb.com/name/{imdbId}/";
        return string.IsNullOrEmpty(path) ? baseUrl + "?ref_=tt_rvi_t_3" : baseUrl + path;
    }
    public static string BuildSearchUrl(string movieName)
    {
        string baseUrl = $"https://m.imdb.com/find?q={Uri.EscapeDataString(movieName)}";
        return baseUrl;
    }
}
