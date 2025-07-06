using CinemaBox.Libretranslate.Interface;
using Newtonsoft.Json.Linq;
using System.Text;

namespace CinemaBox.Libretranslate;

public  class Translate: ITranslate
{
    public async Task<string> TranslateText(string text)
    {
        string from = "auto";
        string to = "fa";
        var client = new HttpClient();

        var json = new JObject
        {
            ["q"] = text,
            ["source"] = from,
            ["target"] = to,
            ["format"] = "text"
        };

        var content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");

        try
        {
            HttpResponseMessage response = await client.PostAsync("http://localhost:5000/translate", content);
            response.EnsureSuccessStatusCode();

            string result = await response.Content.ReadAsStringAsync();
            JObject obj = JObject.Parse(result);
            return obj["translatedText"]?.ToString() ?? "";
        }
        catch (Exception ex)
        {
            return "خطا در ترجمه: " + ex.Message;
        }
    }
}

