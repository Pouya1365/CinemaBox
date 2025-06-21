namespace CinemaBox.Utilities.Download;


public static class ImageExtension
{
    private static readonly HttpClient _httpClient = new();
    public static async Task<byte[]> DownloadFile(string url) => await _httpClient.GetByteArrayAsync(url);
  
}
