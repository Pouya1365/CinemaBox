using CinemaBox.Libretranslate.Interface;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CinemaBox.Libretranslate;

public class Translate : ITranslate
{
    private readonly HttpClient _client = new();
    public async Task<string> TranslateText(string text)
    {
        if (text is null)
            return null;

        var parts = SplitTextByWords(text);
        var result = new StringBuilder();
        foreach (var part in parts)
        {


            string url = $"https://translate.google.com/m?sl=auto&hl=fa&q={Uri.EscapeDataString(part)}";

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/115.0.0.0 Safari/537.36");
            request.Headers.Add("Accept-Language", "fa-IR,fa;q=0.9,en-US;q=0.8,en;q=0.7");
            request.Headers.Referrer = new Uri("https://translate.google.com/");
            request.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8");
            try
            {
                HttpResponseMessage response = await _client.SendAsync(request);
                if (!response.IsSuccessStatusCode)
                    return null;
                string content = await response.Content.ReadAsStringAsync();
                Match match = Regex.Match(content, @"<div\s+class=""result-container"">(.*?)<\/div>", RegexOptions.Singleline | RegexOptions.IgnoreCase);
                if (match.Success)
                {
                    result.Append(System.Net.WebUtility.HtmlDecode(match.Groups[1].Value));
                    result.Append(" ");
                }
            }
            catch (Exception)
            {

             await   TranslateText( text);
            }                   
        }
        return result.ToString().Trim();
    }




    public List<string> SplitTextByWords(string text, int wordsPerChunk = 300)
    {
        var words = text.Split(new[] { ' ', '\r', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        var chunks = new List<string>();

        for (int i = 0; i < words.Length; i += wordsPerChunk)
        {
            var chunkWords = words.Skip(i).Take(wordsPerChunk);
            chunks.Add(string.Join(" ", chunkWords));
        }

        return chunks;
    }
}

