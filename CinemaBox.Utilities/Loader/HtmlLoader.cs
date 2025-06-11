using HtmlAgilityPack;

namespace CinemaBox.Utilities.Loader;
public static class HtmlLoader
{
    public static async Task<HtmlDocument> LoadDocumentAsync(string url)
    {
        HtmlWeb web = new();
        return await web.LoadFromWebAsync(url);
    }
}