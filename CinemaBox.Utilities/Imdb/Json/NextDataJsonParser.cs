using HtmlAgilityPack;
using System.Text.Json;

namespace CinemaBox.Utilities.Imdb.Json;

public static class NextDataJsonParser 
{
    public static JsonDocument? Parse(HtmlDocument document)
    {
        HtmlNode? nextDataNode = document.DocumentNode.SelectSingleNode("//script[@id='__NEXT_DATA__']");
        if (nextDataNode == null || string.IsNullOrWhiteSpace(nextDataNode.InnerText))
            return null;
        try
        {
            return JsonDocument.Parse(nextDataNode.InnerText);
        }
        catch (JsonException)
        {
            return null;
        }
    }
}