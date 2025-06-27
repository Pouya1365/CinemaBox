using System.Text.RegularExpressions;

namespace CinemaBox.Utilities.Download;


public static class ImageExtension
{
    private static readonly HttpClient _httpClient = new();
    public static async Task<byte[]> DownloadFile(string url)
    {
        byte[] image = [];
        try
        {
            image = await _httpClient.GetByteArrayAsync(url);
        }
        catch (Exception)
        {
            image = await DownloadFile(CleanNotFoundImageUrl(url: url));
        }
        return image;
    }
    public static string CleanImageUrl(string url)
    {
        if (string.IsNullOrEmpty(url))
            return url;

        if (!url.Contains("_V1"))
            return url;

        Regex regex = new(@"\@.*(?=\.(jpg|jpeg|png|webp))", RegexOptions.IgnoreCase);
        return regex.Replace(url, "@@._V1");
    }
    public static string CleanNotFoundImageUrl(string url)
    {
        if (string.IsNullOrEmpty(url))
            return url;

        if (!url.Contains("_V1"))
            return url;

        return url.Replace("@@._V1", "@._V1");
    }
}
