using System.Net;

namespace CinemaBox.Utilities.Html
{
    public static class HtmlDecode
    {
        public static string HtmlDecoding(string input) => WebUtility.HtmlDecode(input);
    }
}
